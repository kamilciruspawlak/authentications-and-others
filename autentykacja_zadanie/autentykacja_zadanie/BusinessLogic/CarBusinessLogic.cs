using autentykacja_zadanie.Intetfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentykacja_zadanie.BusinessLogic
{
    public class CarBusinessLogic : ICarBusinessLogic
    {
        public string CheckIfUserIsAuthAndReturnName()
        {
            string name = "Niezalogowany";
            if (CheckIfUserIsAuthorize())
            {
                name = HttpContext.Current.User.Identity.Name;
            }
            return name;
        }
        public bool CheckIfUserIsAuthorize()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}