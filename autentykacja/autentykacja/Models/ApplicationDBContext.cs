using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace autentykacja.Models
{
    public class ApplicationDBContext : DbContext
    {   
        public ApplicationDBContext() : base("Car")
            {

            }
        public DbSet<Car>Car { get; set; }
    }
}