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
    /// <summary>
    /// 
    /// </summary>
    public class CountryDAL :_BaseDAL, ICommonDAL<Country>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public CountryDAL(string connectionString) : base(connectionString)
        {

        }

        public int Add(Country data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Country Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }


        public IList<Country> List(int page, int pageSize, string searchValue)
        {
            List<Country> data = new List<Country>();

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT *
                                    FROM
                                    (
                                        SELECT    *, ROW_NUMBER() OVER (ORDER BY CountryName) AS RowNumber
                                        FROM    Countries
                                        WHERE    (@searchValue = N'')
                                            OR    (
                                                    (CountryName LIKE @searchValue)
                                                )
                                    ) AS t
                                    WHERE (@pageSize = 0) OR (t.RowNumber BETWEEN (@page - 1) * @pageSize + 1 AND @page * @pageSize)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dbReader.Read())
                {
                    data.Add(new Country()
                    {
                        ContryName = Convert.ToString(dbReader["CountryName"])
                    });


                }
                cn.Close();
            }

            return data;
        }

        public bool Update(Country data)
        {
            throw new NotImplementedException();
        }
    }
}
