using autentykacja_zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentykacja_zadanie.ViewModels
{
    public class VMCars
    {
        public CarEntity Car { get; set; }
        public List<CarEntity> CarList { get; set; }
        public bool ShowIfAuth { get; set; }
    }
}