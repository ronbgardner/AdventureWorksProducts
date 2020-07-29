using System;

namespace AdventureWorksProducts.DataAccess
{
    /// <summary>
    /// Unit of work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Product
        /// </summary>
        IProductRepository Product { get; }
    }
}
