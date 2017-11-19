using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adresyIOsoby.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Ulica { get; set; }
        public string Miejscowosc { get; set; }
        public string KodPocztowy { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}