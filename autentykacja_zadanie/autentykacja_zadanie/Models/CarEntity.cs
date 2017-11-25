using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentykacja_zadanie.Models
{
    public class CarEntity : IBasicEntity
    {
        public DateTime DateCreate{ get; set; }
        public DateTime DateMod   { get; set; }
        public int Id { get; set; }
        public bool isActive { get ; set ; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string ModPerson { get; set; }
        public string RegistrationNumber { get; set; }
    }
}