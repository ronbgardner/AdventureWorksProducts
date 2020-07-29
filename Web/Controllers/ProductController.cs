using System.Collections.Generic;
using AdventureWorksProducts.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdventureWorksProducts.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _Logger;
        private readonly IUnitOfWork _UnitOfWork;

        public ProductController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            this._Logger = logger;
            this._UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Product view
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Product detail
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>View</returns>
        public IActionResult ProductDetail(int id)
        {
            return View(id);
        }

        #region API

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>JSON</returns>
        public IActionResult GetAllProducts()
        {
            return (Json(new { data = this._UnitOfWork.Product.GetAll() }));
        }

        /// <summary>
        /// Get product detail data
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>JSON</returns>
        public IActionResult GetProduct(int id)
        {
            var product = this._UnitOfWork.Product.Get(id);

            if (product != null)
            {
                var productDetail = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("ProductID", product.ProductId.ToString()),
                    new KeyValuePair<string, string>("Name", product.Name),
                    new KeyValuePair<string, string>("Color", product.Color),
                    new KeyValuePair<string, string>("Size", product.Size),
                };

                return (Json(new { data = productDetail }));
            }
            else
                return NotFound();
        }

        /// <summary>
        /// Get product cost history data
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>JSON</returns>
        public IActionResult ProductCostHistories(int id)
        {
            return (Json(new { data = this._UnitOfWork.Product.GetProductCostHistories(id) }));
        }

        #endregion API
    }
}
