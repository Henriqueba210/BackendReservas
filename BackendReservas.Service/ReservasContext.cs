using System;
using System.Collections.Generic;
using BackendReservas.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendReservas.Service
{
    public class ReservasContext : DbContext
    {
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Fidelidade> Fidelidades { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        public ReservasContext(DbContextOptions<ReservasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Fidelidades)
                .WithOne(f => f.Cliente)
                .HasForeignKey(f => f.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Avaliacoes)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Reservas)
                .WithOne(r => r.Cliente)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<Estabelecimento>()
                .HasMany(e => e.Fidelidades)
                .WithOne(f => f.Estabelelecimento)
                .HasForeignKey(f => f.EstablelecimentoId);
            
            modelBuilder.Entity<Estabelecimento>()
                .HasMany(e => e.Avaliacoes)
                .WithOne(a => a.Estabelelecimento)
                .HasForeignKey(a => a.EstablelecimentoId);

            modelBuilder.Entity<Estabelecimento>()
                .HasMany(e => e.Reservas)
                .WithOne(r => r.Estabelelecimento)
                .HasForeignKey(a => a.EstablelecimentoId);

            var endereco = new Endereco(1, "Avenida Nossa Senhora de Fátima", 850, "Vila Israel", "Americana", "SP", "Brasil", "13478540");

            modelBuilder.Entity<Endereco>().HasData(endereco);

            var clientes = new List<Cliente> {
                new Cliente(1, "Henrique", "teste@gmail.com", "1234", "19971522927", 1),
                new Cliente(2, "Gabriel Cabral", "teste@gmail.com", "1234", "19971522927", 1),
                new Cliente(3, "Gabriel Oliveira", "teste@gmail.com","1234", "19971522927", 1),
                new Cliente(4, "Carol", "teste@gmail.com", "1234", "19971522927", 1),
                new Cliente(5, "Eliana", "teste@gmail.com","1234", "19971522927", 1)
            };
            modelBuilder.Entity<Cliente>().HasData(clientes);

            var estabelecimento = new Estabelecimento(1, "teste@gmail.com", "18340388000135", "1234", "15" ,  "19971522927", DateTime.Now, "McDonald's", 1);
            modelBuilder.Entity<Estabelecimento>().HasData(estabelecimento);
        }
    }
}
