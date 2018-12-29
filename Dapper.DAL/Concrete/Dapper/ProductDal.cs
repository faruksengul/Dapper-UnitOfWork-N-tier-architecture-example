using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.DAL.Abstract;
using Dapper.Entity;

namespace Dapper.DAL.Concrete.Dapper
{
    public class ProductDal:IProductDal
    {
        protected SqlConnection GetOpenConnection()
        {
            var connnection = new SqlConnection("data source =.; initial catalog = NORTHWND; Integrated Security = True;");
            connnection.Open();
            return connnection;
        }

        public List<Products> GetAll()
        {
            using (var con = GetOpenConnection())
            {
                return con.Query<Products>("select * from Products").ToList();
            }
        }

        public Products Get(int Id)
        {
            using (var con = GetOpenConnection())
            {
                return con.Query<Products>("select * from Products where ProductID=@ProductID", new {ProductID = Id})
                    .FirstOrDefault();
            }
        }

        public void Add(Products entity)
        {
            using (var con = GetOpenConnection())
            {
                string SqlQuery =
                    "Insert Products(ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) values(@ProductID,@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)";
                con.Execute(SqlQuery, entity);
            }
        }

        public void Delete(Products entity)
        {
            using (var con = GetOpenConnection())
            {
                con.Query<Products>("delete from Products where ProductID=@ProductID",
                    new {ProductID = entity.ProductID});

            }
        }

        public void Update(Products entity)
        {
            using (var con = GetOpenConnection())
            {
                string SqlQuery = "update Products set ProductName=@ProductName,SupplierID=@SupplierID,CategoryID=@CategoryID,QuantityPerUnit=@QuantityPerUnit,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,UnitsOnOrder=@UnitsOnOrder,ReorderLevel=@ReorderLevel,Discontinued=@Discontinued  where ProductID=@ProductID";
                con.Execute(SqlQuery, entity);
            }
           
            
        }
    }
}
