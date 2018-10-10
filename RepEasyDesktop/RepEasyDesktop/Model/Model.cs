namespace RepEasyDesktop.Model
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

        public virtual DbSet<Despesa> Despesas { get; set; }
        public virtual DbSet<Item> Itens { get; set; }
        public virtual DbSet<Morador> Moradores { get; set; }
        public virtual DbSet<MoradorDespesa> MoradoresDespesas { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Despesa>()
                .Property(e => e.Descricao)
                .IsFixedLength();

            modelBuilder.Entity<Despesa>()
                .Property(e => e.Valor)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Despesa>()
                .HasMany(e => e.MoradorDespesa)
                .WithRequired(e => e.Despesa1)
                .HasForeignKey(e => e.Despesa);

            modelBuilder.Entity<Despesa>()
                .HasMany(e => e.Item)
                .WithMany(e => e.Despesa)
                .Map(m => m.ToTable("ItemDespesa").MapLeftKey("Despesa").MapRightKey("Item"));

            modelBuilder.Entity<Item>()
                .Property(e => e.Descricao)
                .IsFixedLength();

            modelBuilder.Entity<Morador>()
                .Property(e => e.Nome)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Morador>()
                .Property(e => e.Cpf)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Morador>()
                .Property(e => e.Senha)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Morador>()
                .HasMany(e => e.MoradorDespesa)
                .WithRequired(e => e.Morador1)
                .HasForeignKey(e => e.Morador);

            modelBuilder.Entity<Morador>()
                .HasMany(e => e.Tarefa)
                .WithMany(e => e.Morador)
                .Map(m => m.ToTable("MoradorTarefa").MapLeftKey("Morador").MapRightKey("Tarefa"));

            modelBuilder.Entity<MoradorDespesa>()
                .Property(e => e.Valor)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Tarefa>()
                .Property(e => e.Titulo)
                .IsFixedLength();

            modelBuilder.Entity<Tarefa>()
                .Property(e => e.Descricao)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
