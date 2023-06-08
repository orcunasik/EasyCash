using EasyCash.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.DataAccess.Concrete
{
    public class EasyCashDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I6RA8LI;Database=EasyCash;Integrated Security=True;");
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAccountProcess>()
                   .HasOne(cap => cap.SenderCustomer)
                   .WithMany(ca => ca.CustomerSender)
                   .HasForeignKey(cap => cap.SenderId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<CustomerAccountProcess>()
                   .HasOne(cap => cap.ReceiverCustomer)
                   .WithMany(ca => ca.CustomerReceiver)
                   .HasForeignKey(cap => cap.ReceiverId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);

        }
    }
}
