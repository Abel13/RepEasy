namespace RepEasyDesktop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recebimento")]
    public partial class Recebimento
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Morador { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Devedor { get; set; }

        public decimal Valor { get; set; }

        public virtual Morador Morador1 { get; set; }

        public virtual Morador Morador2 { get; set; }
    }
}
