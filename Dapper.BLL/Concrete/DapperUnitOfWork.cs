using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.BLL.Abstract;
using Dapper.DAL.Concrete.Dapper;

namespace Dapper.BLL.Concrete
{
    public class DapperUnitOfWork:IUnitOfWork
    {
        private IDbConnection _connection;
       


        private ICustomerService _customer { get; set; }
        private ICategoryService _category { get; set; }
        private IProductService _product { get; set; }

        public ICustomerService Customer
        {
            get { return _customer ?? (_customer = new CustomerManager(new CustomerDal())); }
        }

        public ICategoryService Category
        {
            get { return _category ?? (_category = new CategoryManager(new CategoryDal())); }
        }

        public IProductService Product
        {
            get { return _product ?? (_product = new ProductManager(new ProductDal())); }
        }

       

        public void Dispose()
        {
           

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }


        
    }
}
