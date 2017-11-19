using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cwiczenie.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("BazaDanych")
        {

        }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}