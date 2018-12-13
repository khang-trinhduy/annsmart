using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingForm.Models;

namespace BookingForm.Models
{
    public class BookingFormContext : DbContext
    {
        public BookingFormContext (DbContextOptions<BookingFormContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasMany(b => b.meetings)
                .WithOne();
        }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<Appoinment> appoinment { get; set; }
        public DbSet<Sale> sale { get; set; }
        public DbSet<Logger> Loggers { get; set; }
    }
}
