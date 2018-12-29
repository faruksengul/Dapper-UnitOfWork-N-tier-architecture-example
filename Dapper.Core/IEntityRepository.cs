using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core
{
    public interface IEntityRepository<T> where T: class ,new()
    {
        List<T> GetAll();
        T Get(int Id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
