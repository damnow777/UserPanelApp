using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Users_Kurs_API.Entities;

namespace Users_Kurs_API
{
    public class UserSeeder
    {
        private readonly UserDbContext _dbContext;

        public UserSeeder(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();

                }
            }

        }

        private IEnumerable<User> GetUsers()
        {
            var user = new List<User>()
            {
                new User()
                {
                    Name = "Damian",
                    Lastname = "Nowak",
                    Number = 546785457,

                    Address = new Address()
                    {
                        City = "Nakielno",
                        Street = "Nakielno 40",
                        PostalCode = "78-600"
                    }
                },

                 new User()
                {
                    Name = "Jan",
                    Lastname = "Kowalski",
                    Number = 765234865,

                    Address = new Address()
                    {
                        City = "Poznań",
                        Street = "Wojska Polskiego",
                        PostalCode = "60-681"
                    }
                }
            };

            return user;
        }
    }
}
