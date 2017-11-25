using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autentykacja_zadanie.Intetfaces
{
    public interface ICarBusinessLogic
    {
        string CheckIfUserIsAuthAndReturnName();
        bool CheckIfUserIsAuthorize();
    }
}
