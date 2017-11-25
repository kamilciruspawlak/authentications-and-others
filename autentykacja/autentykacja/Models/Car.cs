using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autentykacja.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime AddDate { get; set; }
        public string WhoAddCar { get; set; }
       
        public string LastModificationPerson { get; set; }

    }
}