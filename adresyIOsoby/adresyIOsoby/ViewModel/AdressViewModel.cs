using adresyIOsoby.Valid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adresyIOsoby.ViewModel
{
    public class AdressViewModel
    {
        public int Id { get; set; }
        public string Ulica { get; set; }
        public string Miejscowosc { get; set; }
        [AdressValidator]
        public string KodPocztowy { get; set; }
    }
}