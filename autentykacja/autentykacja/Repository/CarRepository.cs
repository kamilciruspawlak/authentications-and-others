using autentykacja.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentykacja.Repository
{
    public class CarRepository : AbstractRepository<Models.Car>, ICarRepository
    {
    }
}