using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DomainModel;

namespace SV18T1021293.DataLayer.SQLServer
{
    public class ProductAttributeDAL : _BaseDAL, IProductAttribiteDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public ProductAttributeDAL(string connectionString) : base(connectionString)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(ProductAttribute data)
        {
            int result = 0;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"insert into ProductAttributes(ProductID,AttributeName,AttributeValue,DisplayOrder)
                                    values(@productID,@attributeName,@attributeValue,@displayOrder) 

                                    SELECT SCOPE_IDENTITY()";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@productID", data.ProductID);
                cmd.Parameters.AddWithValue("@attributeName", data.AttributeName);
                cmd.Parameters.AddWithValue("@attributeValue", data.AttributeValue);
                cmd.Parameters.AddWithValue("@displayOrder", data.DisplayOrder);


                result = Convert.ToInt32(cmd.ExecuteScalar());


                cn.Close();
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public bool Delete(int attributeID)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM ProductAttributes WHERE AttributeID = @attributeID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@attributeID", attributeID);

                result = cmd.ExecuteNonQuery() > 0;
                cn.Close();
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public ProductAttribute Get(int attributeID)
        {
            ProductAttribute result = null;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * From ProductAttributes Where attributeID = @attributeID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@attributeID", attributeID);

                var dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dbReader.Read())
                {
                    result = new ProductAttribute()
                    {
                        AttributeID = Convert.ToInt32(dbReader["AttributeID"]),
                        ProductID = Convert.ToInt32(dbReader["ProductID"]),
                        AttributeName = Convert.ToString(dbReader["AttributeName"]),
                        AttributeValue = Convert.ToString(dbReader["AttributeValue"]),
                        DisplayOrder = Convert.ToInt32(dbReader["DisplayOrder"]),
                    };
                }

                cn.Close();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public IList<ProductAttribute> List(int productID)
        {
            List<ProductAttribute> data = new List<ProductAttribute>();

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from ProductAttributes
                                    where ProductID = @productID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@productID", productID);
                SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dbReader.Read())
                {
                    data.Add(new ProductAttribute()
                    {
                        AttributeID = Convert.ToInt32(dbReader["AttributeID"]),
                        ProductID = Convert.ToInt32(dbReader["ProductID"]),
                        AttributeName = Convert.ToString(dbReader["AttributeName"]),
                        AttributeValue = Convert.ToString(dbReader["AttributeValue"]),
                        DisplayOrder = Convert.ToInt32(dbReader["DisplayOrder"]),
                    });
                }
                dbReader.Close();
                cn.Close();
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(ProductAttribute data)
        {

            bool result = false;

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"update ProductAttributes
                                    set ProductID = @productID,
	                                    AttributeName = @attributeName,
                                        AttributeValue = @attributeValue,
	                                    DisplayOrder = @displayOrder
                                     where AttributeID = @attributeID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@productID", data.ProductID);
                cmd.Parameters.AddWithValue("@attributeName", data.AttributeName);
                cmd.Parameters.AddWithValue("@attributeValue", data.AttributeValue);
                cmd.Parameters.AddWithValue("@displayOrder", data.DisplayOrder);
                cmd.Parameters.AddWithValue("@attributeID", data.AttributeID);


                result = cmd.ExecuteNonQuery() > 0;


                cn.Close();
            }

            return result;
        }
    }
}
