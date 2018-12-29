using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper.DAL.Abstract;
using Dapper.Entity;

namespace Dapper.DAL.Concrete.Dapper
{
    public class CategoryDal:ICategoryDal
    {

        protected SqlConnection GetOpenConnection()
        {
            var connnection = new SqlConnection("data source =.; initial catalog = NORTHWND; Integrated Security = True;");
            connnection.Open();
            return connnection;
        }


        public List<Categories> GetAll()
        {
            using (var con = GetOpenConnection())
            {
                return con.Query<Categories>("select * from Categories").ToList();
            }
        }

        public Categories Get(int Id)
        {
            using (var con = GetOpenConnection())
            {
                return con.Query<Categories>("select * from Categories where CategoryID=@Id", new {Id})
                    .SingleOrDefault();
            }
        }

        public void Add(Categories entity)
        {
            using (var con = GetOpenConnection())
            {
                string SqlQuery =
                    "Insert Categories(CategoryID,CategoryName,Description) values (@CategoryID,@CategoryName,@Description)";
                con.Execute(SqlQuery, entity);
            }
        }

        public void Delete(Categories entity)
        {
            using (var con = GetOpenConnection())
            {
                con.Query<Categories>("delete from Categories where CategoryID=@Id", new {Id = entity.CategoryID});
            }
        }

        public void Update(Categories entity)
        {
            using (var con = GetOpenConnection())
            {
                string SqlQuery = "update Categories set CategoryName=@CategoryName,Description=@Description where CategoryID=CategoryID";
                con.Execute(SqlQuery, entity);
            }   
        }
    }
}
