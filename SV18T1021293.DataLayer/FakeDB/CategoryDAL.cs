using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DomainModel;

namespace SV18T1021293.DataLayer.FakeDB
{
    /// <summary>
    /// Cài đặt chức năng xử lý dữ liệu trên loại hàng theo kiểu Fake
    /// </summary>
    public class CategoryDAL : ICategoryDAL

    {
        public int Add(Category data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int categoryID)
        {
            throw new NotImplementedException();
        }

        public Category Get(int categoryID)
        {
            throw new NotImplementedException();
        }

        public IList<Category> List()
        {
            List<Category> data = new List<Category>();

            data.Add(new Category() {
                
                
            });

            return data;
        }

        public int Update(Category data)
        {
            throw new NotImplementedException();
        }
    }
}
