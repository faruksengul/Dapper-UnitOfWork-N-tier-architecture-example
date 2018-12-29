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
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Categories> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Categories Get(int Id)
        {
            return _categoryDal.Get(Id);
        }

        public void Update(Categories entity)
        {
            _categoryDal.Update(entity);
        }

        public void Delete(Categories entity)
        {
            _categoryDal.Delete(entity);
        }

        public void Add(Categories entity)
        {
            _categoryDal.Add(entity);
        }
    }
}
