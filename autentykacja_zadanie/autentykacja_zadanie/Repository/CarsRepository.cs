using autentykacja_zadanie.Models;
using autentykacja_zadanie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentykacja_zadanie.Repository
{
    public class CarsRepository : AbstractRepository<CarEntity> , ICarsRepository
    { 
    }
}