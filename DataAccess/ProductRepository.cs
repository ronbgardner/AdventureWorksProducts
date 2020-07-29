using System;
using System.Collections.Generic;
using System.Linq;
using AdventureWorksProducts.Models;

namespace AdventureWorksProducts.DataAccess
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._DbContext = dbContext;
        }

        public IEnumerable<ProductCostHistory> GetProductCostHistories(int id)
        {
            IEnumerable<ProductCostHistory> productCostHistories = null;

            try
            {
                var queryProductCostHistory = this._DbContext.ProductCostHistory.Where(element => element.ProductId == id);

                productCostHistories = queryProductCostHistory.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return productCostHistories;
        }
    }
}
