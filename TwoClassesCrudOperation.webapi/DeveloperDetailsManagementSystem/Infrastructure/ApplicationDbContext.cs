using DeveloperDetailsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeveloperDetailsManagementSystem.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            //seeding Data dor Address Table
            modelBuilder.Entity<Address>().HasData(

                new Address { Id=1,Country="Nepal"},
                new Address { Id=2,Country="India"},
                new Address { Id=3,Country="Bangladesh"},
                new Address { Id=4,Country="China"},
                new Address { Id=5,Country="Pakistan"},
                new Address { Id=6,Country="Japan"},
                new Address { Id=7,Country="USA"},
                new Address { Id=8,Country="Uk"},
                new Address { Id=9,Country="Brazil"},
                new Address { Id=10,Country="Spain"}
                
                );
            
            modelBuilder.Entity<Developer>()
                .Property(d => d.EstimateIncome)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Developer>()
               .HasOne(d => d.Address)
               .WithMany(a => a.Developers)
               .HasForeignKey(d => d.AddressId)
               .OnDelete(DeleteBehavior.ClientCascade);
         base.OnModelCreating(modelBuilder);

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Developer> Developers { get; set; }

    }
}
