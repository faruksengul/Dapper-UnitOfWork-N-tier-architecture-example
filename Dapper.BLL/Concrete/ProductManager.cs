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
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Products> GetAll()
        {
            return _productDal.GetAll();
        }

        public Products Get(int Id)
        {
            return _productDal.Get(Id);
        }

        public void Add(Products entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Products entity)
        {
            _productDal.Delete(entity);
        }

        public void Update(Products entity)
        {
            _productDal.Update(entity);
        }
    }
}
