using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.BLL.Abstract
{
    public interface IUnitOfWork:IDisposable
    {

         ICustomerService Customer { get; }
         ICategoryService Category { get; }
         IProductService Product { get; }
    }
}
