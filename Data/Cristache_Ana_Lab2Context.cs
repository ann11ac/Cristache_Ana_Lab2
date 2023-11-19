using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cristache_Ana_Lab2.Models;

namespace Cristache_Ana_Lab2.Data
{
    public class Cristache_Ana_Lab2Context : DbContext
    {
        public Cristache_Ana_Lab2Context (DbContextOptions<Cristache_Ana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Cristache_Ana_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Cristache_Ana_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Cristache_Ana_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Cristache_Ana_Lab2.Models.Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(b => b.Book)
                .HasForeignKey<Borrowing>(b => b.BookID);
        }
        public DbSet<Cristache_Ana_Lab2.Models.Member>? Member { get; set; }
        public DbSet<Cristache_Ana_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
