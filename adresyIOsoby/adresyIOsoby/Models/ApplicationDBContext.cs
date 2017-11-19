using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace adresyIOsoby.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("Polaczonabaza")
        {

        }
        public DbSet<Adress> Adresy { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}