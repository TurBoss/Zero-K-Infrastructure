﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ZeroKLobby
{
    public class ButtonInfo: INotifyPropertyChanged
    {
        bool isAlerting;
        bool isSelected;
        public bool IsAlerting {
            get { return isAlerting; }
            set {
                var changed = isAlerting != value;
                isAlerting = value;
                button.BackColor = isAlerting ? Color.Red : Color.Transparent;
                if (changed) InvokePropertyChanged("IsAlerting");
            }
        }
        public bool IsSelected {
            get { return isSelected; }
            set {
                var changed = isSelected != value;
                isSelected = value;
                //button.BackColor = isSelected ? Color.PowderBlue : SystemColors.ButtonFace;
                button.ForeColor = isSelected ? Color.Aqua: Color.White;
                if (changed) InvokePropertyChanged("IsSelected");
            }
        }
        public string Label { get; set; }
        /// <summary>
        /// If true, lobby wont remember subpath for this button and instead go directly to target location
        /// </summary>
        public string TargetPath;
        Button button;
        public bool Visible { get; set; }

        public Bitmap Icon { get; set; }

        public ButtonInfo() {
            Visible = true;
        }

        void InvokePropertyChanged(string name) {
            var changed = PropertyChanged;
            if (changed != null) changed(this, new PropertyChangedEventArgs(name));
        }

        public Control GetButton() {
            button = new BitmapButton();
            //button.AutoSize = true;
            //button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button.Height = 25;
            button.Width = 100;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Text = Label;
            if (Icon != null) {
                button.Image = Icon;
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
            button.Click += (sender, args) =>
                { Program.MainWindow.navigationControl.SwitchTab(TargetPath); };
            return button;

        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}