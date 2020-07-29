using System.Collections.Generic;
using AdventureWorksProducts.Models;

namespace AdventureWorksProducts.DataAccess
{
    /// <summary>
    /// Product Repository Interface
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Get Cost History data for a Product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns></returns>
        IEnumerable<ProductCostHistory> GetProductCostHistories(int id);
    }
}
