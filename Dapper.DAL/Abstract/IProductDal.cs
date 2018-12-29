using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core;
using Dapper.Entity;

namespace Dapper.DAL.Abstract
{
    public interface IProductDal:IEntityRepository<Products>
    {
    }
}
