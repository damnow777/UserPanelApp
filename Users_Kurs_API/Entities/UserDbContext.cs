using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Kurs_API.Entities
{
    public class UserDbContext : DbContext
    {
        private string _connectingString = "Server = DESKTOP-7N5UPVB\\SQLEXPRESS; Database = Users_Kurs_API; Trusted_connection = True";

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);
            model.Entity<User>()
                .Property(x => x.Lastname)
                .IsRequired()
                .HasMaxLength(25);

            model.Entity<Address>()
                .Property(x => x.City)
                .IsRequired();
            model.Entity<Address>()
                .Property(x => x.Street)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectingString);
        }

    }
}
