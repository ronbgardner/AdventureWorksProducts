using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksProducts.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext Context { get; }

        private DbSet<T> _DbSet;

        public Repository(DbContext context)
        {
            this.Context = context;
            this._DbSet = this.Context.Set<T>();
        }

        public T Get(int id)
        {
            return this._DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = this._DbSet;

            return query.ToList();
        }
    }
}
