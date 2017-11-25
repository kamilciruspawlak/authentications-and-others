using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace autentykacja_zadanie.Repository.Interfaces
{
    public interface IAbstractRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        List<T> GetWhere(Expression<Func<T, bool>> expression);
        void Delete(T entity);
    }
}
