namespace RepEasyDesktop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoradorTarefa")]
    public partial class MoradorTarefa
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Morador { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tarefa { get; set; }

        public virtual Tarefa Tarefa1 { get; set; }

        public virtual Morador Morador1 { get; set; }
    }
}
