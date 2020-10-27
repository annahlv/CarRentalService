using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;

namespace DiplomProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options) {
        }
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderState> States { get; set; }
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationApplicationUser> UserNotifications { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

        }
    }
    public class ApplicationDbContextFactory
            : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public ApplicationDbContext CreateDbContext(string[] args) =>
            Program.CreateHostBuilder(args).Build().Services
                .GetRequiredService<ApplicationDbContext>();
    }
}
