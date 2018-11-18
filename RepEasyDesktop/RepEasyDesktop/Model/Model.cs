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
        public virtual DbSet<Recebimento> Recebimentos { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Despesa>()
                .Property(e => e.Descricao)
                .IsFixedLength();

            modelBuilder.Entity<Despesa>()
                .Property(e => e.Valor)
                .HasPrecision(7, 2);

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
                .IsUnicode(false);

            modelBuilder.Entity<Morador>()
                .Property(e => e.Cpf)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Morador>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Morador>()
                .HasMany(e => e.MoradorDespesa)
                .WithRequired(e => e.Morador1)
                .HasForeignKey(e => e.Morador);

            modelBuilder.Entity<Morador>()
                .HasMany(e => e.MoradorDespesa1)
                .WithRequired(e => e.Morador2)
                .HasForeignKey(e => e.Responsavel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Morador>()
                .HasMany(e => e.Recebimento)
                .WithRequired(e => e.Morador1)
                .HasForeignKey(e => e.Devedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Morador>()
                .HasMany(e => e.Recebimento1)
                .WithRequired(e => e.Morador2)
                .HasForeignKey(e => e.Morador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Morador>()
                .HasMany(e => e.Tarefa)
                .WithMany(e => e.Morador)
                .Map(m => m.ToTable("MoradorTarefa").MapLeftKey("Morador").MapRightKey("Tarefa"));

            modelBuilder.Entity<MoradorDespesa>()
                .Property(e => e.Valor)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Recebimento>()
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
