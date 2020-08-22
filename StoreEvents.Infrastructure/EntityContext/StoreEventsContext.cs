using Microsoft.EntityFrameworkCore;
using StoreEvents.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreEvents.Infrastructure.EntityContext
{
    public class StoreEventsContext : DbContext
    {
        public StoreEventsContext( DbContextOptions options) : base(options) { }

        public DbSet<Cupom> Cupons { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cupom>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Promocao>()
                .HasKey(e => e.Id);
        }

    }
}
