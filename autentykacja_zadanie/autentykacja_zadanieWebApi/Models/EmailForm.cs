using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autentykacja_zadanieWebApi.Models
{
    public class EmailForm
    {
       
        public string Topic { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}