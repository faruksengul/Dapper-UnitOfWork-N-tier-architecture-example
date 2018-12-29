using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.BLL.Abstract;
using Dapper.DAL.Abstract;
using Dapper.Entity;

namespace Dapper.BLL.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customers> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customers Get(int Id)
        {
            return _customerDal.Get(Id);
        }

        public void Add(Customers entity)
        {
            _customerDal.Add(entity);
        }

        public void Delete(Customers entity)
        {
            _customerDal.Delete(entity);
        }

        public void Update(Customers entity)
        {
            _customerDal.Update(entity);
        }
    }
}
