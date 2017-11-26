using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentykacja_zadanie.ApiConsumer.Model
{
    public class EmailApiModel
    {
        public string Topic { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}