using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core
{
    public interface IEntityService<T> where T:class,new()
    {
        List<T> GetAll();
        T Get(int Id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
