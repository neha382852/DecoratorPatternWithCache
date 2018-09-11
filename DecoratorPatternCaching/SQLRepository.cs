using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternCaching
{
    class SQLRepository : IRepository
    {
        private SqlConnection connect;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK045;Initial Catalog=ProductCaching;User Id=sa;Password=test123!@#";
            connect = new SqlConnection(constr);

        }
        public List<Product> GetAllProducts()
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand(query, connect)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();
            connect.Open();
            dataadapter.Fill(datatable);
            connect.Close();
            foreach (DataRow datarow in datatable.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(datarow["Id"]),
                        name = Convert.ToString(datarow["name"]),
                        price = (float)Convert.ToDouble(datarow["price"])
                    }
                );

            }
            return productList;
        }

        public Product GetProductById(int id)
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Products where Id=" + id;
            SqlCommand command = new SqlCommand(query, connect)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();
            connect.Open();
            dataadapter.Fill(datatable);
            connect.Close();
            foreach (DataRow datarow in datatable.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(datarow["Id"]),
                        name = Convert.ToString(datarow["name"]),
                        price = (float)Convert.ToDouble(datarow["price"])
                    }
                );

            }
            return productList[0];
        }
    }
}
