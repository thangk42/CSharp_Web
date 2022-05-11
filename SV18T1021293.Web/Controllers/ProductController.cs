using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SV18T1021293.BusinessLayer;
using SV18T1021293.DomainModel;

namespace SV18T1021293.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [RoutePrefix("product")]
    public class ProductController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Models.PaginationSearchInput model = Session["PRODUCT_SEARCH"] as Models.PaginationSearchInput;
            if (model == null)
            {
                model = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = 5,
                    SearchValue = "",
                    CategoryID = 0,
                    SupplierID = 0
                };
            }
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult Search(Models.ProductPaginationSearchInput input)
        {
            int rowCount = 0;
            var data = ProductDataService.ListOfProducts(input.Page, input.PageSize, input.SearchValue, Convert.ToInt32(input.CategoryID), Convert.ToInt32(input.SupplierID), out rowCount);

            Models.BasePaginationResult model = new Models.ProductPaginationResult
            {
                Page = input.Page,
                PageSize = input.PageSize,
                RowCount = rowCount,
                SearchValue = input.SearchValue,
                SupplierID = Convert.ToInt32(input.supplierID),
                CategoryID = Convert.ToInt32(input.categoryID),
                Data = data
            };

            Session["PRODUCT_SEARCH"] = input;
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            Product model = new Product()
            {
                ProductID = 0
            };
            ViewBag.Title = "Bổ sung mặt hàng ";

            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [Route("edit/{productID}")]
        public ActionResult Edit(string productID)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(productID);
            }
            catch
            {
                return RedirectToAction("Index");
            }
            Product model = ProductDataService.GetProduct(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Cập nhật thông tin khách hàng";
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="uploadPhoto"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public ActionResult Save(Product model, HttpPostedFileWrapper uploadPhoto, string priceInput)
        {
            
            //TODO: Kiểm tra FirstName, LastName, Email, Note,...

            if (string.IsNullOrWhiteSpace(model.ProductName))
                ModelState.AddModelError("ProductName", "Tên không được để trống");
            if (model.SupplierID == 0)
                ModelState.AddModelError("SupplierID", "Nhà cung cấp không được để trống");
            if (model.CategoryID == 0)
                ModelState.AddModelError("CategoryID", "Loại hàng không được để trống");
            if (string.IsNullOrWhiteSpace(model.Unit))
                ModelState.AddModelError("Unit", "Đơn vị tính không được để trống");
            if (string.IsNullOrWhiteSpace(model.Photo) && uploadPhoto == null)
                ModelState.AddModelError("Photo", "Ảnh không không được để trống");
            //Chuyển Price sang kiểu double
            try
            {
                model.Price = double.Parse(priceInput);
            }
            catch
            {
                ModelState.AddModelError("Price", $"Giá {priceInput} ko đúng định dạng 00,00");

            }

            //Upload ảnh
            if (uploadPhoto != null)
            {
                string physicalPath = Server.MapPath("~/Images/Products");
                string filename = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string filePath = System.IO.Path.Combine(physicalPath, filename);
                uploadPhoto.SaveAs(filePath);
                model.Photo = $"Images/Products/{filename}";
            }
            
            if (!ModelState.IsValid)
            {
                ViewBag.Title = model.ProductID == 0 ? "Bổ sung sản phẩm" : "Cập nhật sản phẩm";                    
                return View(model.ProductID == 0 ? "Create" : "Edit", model);
            }
            if (model.ProductID == 0)
            {
                ProductDataService.AddProduct(model);
                return RedirectToAction("Index");
            }
            else
            {
                ProductDataService.UpdateProduct(model);
                return RedirectToAction("Index");

            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        [Route("delete/{productID}")]
        public ActionResult Delete(string productID)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(productID);
            }
            catch
            {
                return RedirectToAction("Index");
            }
            var model = ProductDataService.GetProduct(id);
            if (Request.HttpMethod == "POST")
            {
                // delete image product
                if (string.IsNullOrWhiteSpace(model.Photo))
                {
                    string fullPath = Server.MapPath("~/Images/Products/" + model.Photo);
                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);
                }
                // delete image product photo
                foreach (var p in ProductDataService.ListOfProductPhotos(id))
                {
                    string fullPath = Server.MapPath("~/Images/ProductPhotos/" + p.Photo);
                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);
                }
                ProductDataService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="productID"></param>
        /// <param name="photoID"></param>
        /// <returns></returns>
        [Route("photo/{method}/{productID}/{photoID?}")]
        public ActionResult Photo(string method, int? productID, int? photoID)
        {
          
            ProductPhoto model = null;
            switch (method)
            {
                case "add":
                    model = new ProductPhoto()
                    {
                        PhotoID = 0,
                        ProductID = productID.Value
                    };
                    ViewBag.Title = "Bổ sung ảnh";
                    break;
                case "edit":
                     if(productID.HasValue == false)
            {
                return RedirectToAction("Index");
            }
            if (photoID.HasValue == false)
            {
                return RedirectToAction("Edit", new { productID = productID });

            }
                    model = ProductDataService.GetProductPhoto((int)photoID);
                    if(model == null)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.Title = "Thay đổi ảnh";
                    break;
                case "delete":
                    var mode = ProductDataService.GetProductPhoto(photoID.Value);
                    string fullPath = Server.MapPath("~/Images/" + mode.Photo);
                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);
                    ProductDataService.DeleteProductPhoto(photoID.Value);
                    return RedirectToAction("Edit", new { productID = productID });
                default:
                    return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="productID"></param>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        [Route("attribute/{method}/{productID}/{attributeID?}")]
        public ActionResult Attribute(string method, int? productID, int? attributeID)
        {
           
                ProductAttribute model = null;
            switch (method)
            {
                case "add":
                     model = new ProductAttribute()
                    {
                        AttributeID = 0,
                        ProductID = productID.Value
                     };
                    ViewBag.Title = "Bổ sung thuộc tính";
                    break;
                case "edit":
                    if (productID.HasValue == false)
                    {
                        return RedirectToAction("Index");
                    }
                    if (attributeID.HasValue == false)
                    {
                        return RedirectToAction("Edit", new { productID = productID });

                    }
                    model = ProductDataService.GetProductAttribute((int)attributeID);
                    ViewBag.Title = "Thay đổi thuộc tính";
                    break;
                case "delete":
                    ProductDataService.DeleteProductAttribute((int)attributeID);
                    return RedirectToAction("Edit", new { productID = productID });
                default:
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SavePhoto(ProductPhoto model, HttpPostedFileWrapper uploadPhoto)
        {
            if (string.IsNullOrWhiteSpace(model.Photo) && uploadPhoto == null)
                ModelState.AddModelError("Photo", "Ảnh không không được để trống");
            if (string.IsNullOrWhiteSpace(model.Description))
                ModelState.AddModelError("Description", "Mổ tả không được để trống");
            if (model.DisplayOrder < 1)
                ModelState.AddModelError("DisplayOrder", "Thứ tự hiển thị phải lớn hơn 1");
            //Upload ảnh
            if (uploadPhoto != null)
            {
                string physicalPath = Server.MapPath("~/Images/Products");
                string filename = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string filePath = System.IO.Path.Combine(physicalPath, filename);
                uploadPhoto.SaveAs(filePath);
                model.Photo = $"Images/Products/{filename}";
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Title = model.PhotoID == 0 ? "Bổ sung ảnh" : "Cập nhật ảnh";
                return View("Photo", model);
            }    
            if(model.PhotoID == 0)
            {
                ProductDataService.AddProductPhoto(model);
                return RedirectToAction("Edit", new { productID = model.ProductID });
            }
            else
            {
                ProductDataService.UpdateProductPhoto(model);
                return RedirectToAction("Edit", new { productID = model.ProductID });
            }
        }

        [HttpPost]
        public ActionResult SaveAttribute(ProductAttribute model)
        {
            if (string.IsNullOrWhiteSpace(model.AttributeName))
                ModelState.AddModelError("AttributeName", "Tên thuộc tính không được để trống");
            if (string.IsNullOrWhiteSpace(model.AttributeValue))
                ModelState.AddModelError("AttributeValue", "Gía trị thuộc tính không được để trống");
            if (model.DisplayOrder < 1)
                ModelState.AddModelError("DisplayOrder", "Thứ tự hiển thị phải lớn hơn 1");
            if (!ModelState.IsValid)
            {
                return View("Attribute", model);
            }
            if (model.AttributeID == 0)
            {
                ProductDataService.AddProductAttribute(model);
                return RedirectToAction("Edit", new { productID = model.ProductID });
            }
            else
            {
                ProductDataService.UpdateProductAttribute(model);
                return RedirectToAction("Edit", new { productID = model.ProductID });
            }
        }
    }
}