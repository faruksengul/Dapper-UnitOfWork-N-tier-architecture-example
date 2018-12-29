using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Dapper.BLL.Abstract;
using Dapper.BLL.Concrete;
using Dapper.DAL.Concrete.Dapper;
using Ninject;

namespace Dapper.UI.Ninject
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory()
        {

            _kernel= new StandardKernel();
            //_kernel.Bind<ICategoryService>()
            //    .To<CategoryManager>()
            //    .WithConstructorArgument("categoryDal", new CategoryDal());
            //_kernel.Bind<ICustomerService>()
            //    .To<CustomerManager>()
            //    .WithConstructorArgument("customerDal", new CustomerDal());
            //_kernel.Bind<IProductService>()
            //    .To<ProductManager>()
            //    .WithConstructorArgument("productDal", new ProductDal());
            _kernel.Bind<IUnitOfWork>().To<DapperUnitOfWork>();
            
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)(controllerType == null ? null : _kernel.Get(controllerType));
        }
    }
}