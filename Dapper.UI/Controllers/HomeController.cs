using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper.BLL.Abstract;
using Dapper.BLL.Concrete;

namespace Dapper.UI.Controllers
{
    public class HomeController : Controller
    {
        //aasd
        private readonly IUnitOfWork _unitOf;

        public HomeController(IUnitOfWork unitOf)
        {
            _unitOf = unitOf;
        }

        public ActionResult Index()
        {
            var sonuc = _unitOf.Product.GetAll();
            return null;

        }
    }
}