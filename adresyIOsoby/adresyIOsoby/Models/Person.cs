using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace adresyIOsoby.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

      [ForeignKey("Adress")]
        public int? AdressId { get; set; }

        public virtual Adress Adress { get; set; }
    }
}