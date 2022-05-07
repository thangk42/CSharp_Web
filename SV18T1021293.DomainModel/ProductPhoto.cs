using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV18T1021293.DomainModel
{
    /// <summary>
    /// Thư viện ảnh
    /// </summary>
    public class ProductPhoto
    {
        /// <summary>
        /// Mã ảnh
        /// </summary>
        public int PhotoID { get; set; }
        /// <summary>
        /// Mã Sản Phẩm
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Đường dẫn ảnh
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Mổ tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Thứ tự hiển thị
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// Ẩn ảnh
        /// </summary>
        public Boolean IsHidden { get; set; }
    }
}
