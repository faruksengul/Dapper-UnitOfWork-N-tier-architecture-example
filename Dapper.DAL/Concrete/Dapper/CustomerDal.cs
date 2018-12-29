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
    public class CustomerDal:ICustomerDal
    {

        protected SqlConnection GetOpenConnection()
        {
            var connnection = new SqlConnection("data source =.; initial catalog = NORTHWND; Integrated Security = True;");
            connnection.Open();
            return connnection;
        }

        public List<Customers> GetAll()
        {
            using (var con = GetOpenConnection())
            {
                return con.Query<Customers>("select * from Customers").ToList();
            }
        }

        public Customers Get(int Id)
        {
            using (var con = GetOpenConnection())
            {
                return con.Query<Customers>("select * from Customers where CustomerID =@CustomerID",
                        new {CustomerId = Id})
                    .FirstOrDefault();
            }
        }

        public void Add(Customers entity)
        {
            using (var con = GetOpenConnection())
            {
                string SqlQuery =
                    "Insert Customers(CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax) values (@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)";
                con.Execute(SqlQuery, entity);
            }
           
            
        }

        public void Delete(Customers entity)
        {
            using (var con = GetOpenConnection())
            {
                con.Query<Customers>("delete from Customers where CustomerID=@CustomerID",
                    new {CustomerID = entity.CustomerID});
            }
        }

        public void Update(Customers entity)
        {
            using (var con = GetOpenConnection())
            {
                string SqlQuery =
                    "update Customers set CustomerID=@CustomerID,CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle=@ContactTitle,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,Phone=@Phone,Fax=@Fax  where CustomerID=@CustomerID";
                con.Execute(SqlQuery, entity);
            }
        }
    }
}
