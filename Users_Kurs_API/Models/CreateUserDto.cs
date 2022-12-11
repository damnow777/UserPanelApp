using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Kurs_API.Models
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
