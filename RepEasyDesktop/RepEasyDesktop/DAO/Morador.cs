namespace RepEasyDesktop.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Morador")]
    public partial class Morador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
    }
}
