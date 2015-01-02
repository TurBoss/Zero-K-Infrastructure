namespace ZkData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommanderModule")]
    public partial class CommanderModule
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommanderID { get; set; }

        public int ModuleUnlockID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SlotID { get; set; }

        public virtual Commander Commander { get; set; }

        public virtual CommanderSlot CommanderSlot { get; set; }

        public virtual Unlock Unlock { get; set; }
    }
}
