namespace RepEasyDesktop.DAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Context")
        {
        }

        public virtual DbSet<Morador> Moradors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Morador>()
                .Property(e => e.nome)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Morador>()
                .Property(e => e.cpf)
                .IsFixedLength();

            modelBuilder.Entity<Morador>()
                .Property(e => e.senha)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
