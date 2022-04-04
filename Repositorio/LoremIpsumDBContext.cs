using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entidades;

#nullable disable

namespace Repositorio
{
    public partial class LoremIpsumDBContext : DbContext
    {

        string conexao = @"Server=SQL8001.site4now.net;Database=db_a84f21_matheuspereira;User Id=db_a84f21_matheuspereira_admin;password=12345678mM;MultipleActiveResultSets=true";

        public LoremIpsumDBContext()
        {
        }

        public LoremIpsumDBContext(DbContextOptions<LoremIpsumDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conexao);
            }
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Endereco> enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            #region Cliente
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().
                Property(p => p.nome).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Cliente>().
                Property(p => p.dataNascimento).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Cliente>().
                Property(p => p.sexo).IsRequired().HasColumnType("char(1)");
            #endregion
            #region Endereco
            modelBuilder.Entity<Endereco>().
                Property(p => p.tipoEndereco).IsRequired().HasColumnType("char(1)");
            modelBuilder.Entity<Endereco>().
                Property(p => p.CEP).IsRequired().HasMaxLength(9);
            modelBuilder.Entity<Endereco>().
                Property(p => p.logradouro).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Endereco>().
                Property(p => p.numero).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Endereco>().
                Property(p => p.cidade).IsRequired().HasMaxLength(60); 
            modelBuilder.Entity<Endereco>().
                Property(p => p.UF).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Endereco>().
                Property(p => p.bairro).HasMaxLength(60);
            modelBuilder.Entity<Endereco>().
                Property(p => p.complemento).HasMaxLength(60);
            #endregion
        }

    }
}
