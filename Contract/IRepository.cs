using System.Collections.Generic;

namespace AdventureWorksProducts.DataAccess
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Get data by ID
        /// </summary>
        /// <param name="id">Data ID</param>
        /// <returns></returns>
        T Get(int id);
    }
}
