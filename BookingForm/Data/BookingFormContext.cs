using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingForm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookingForm.Models
{
    public class BookingFormContext : IdentityDbContext<Sale, Role, Guid, UserClaim, UserRole, UserLogin,
        RoleClaim, UserToken>
    {
        public BookingFormContext (DbContextOptions<BookingFormContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Sale>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

        }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<Appoinment> appoinment { get; set; }
        public DbSet<Sale> sale { get; set; }
        public DbSet<Logger> Loggers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Request> Requests { get; set; }    
    }

    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<BookingFormContext>
    {
        BookingFormContext IDesignTimeDbContextFactory<BookingFormContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookingFormContext>();
            optionsBuilder.UseSqlServer<BookingFormContext>("Server=192.168.9.5;Database=annhome.booking; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new BookingFormContext(optionsBuilder.Options);
        }
    }
}
