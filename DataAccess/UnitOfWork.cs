namespace AdventureWorksProducts.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.Context = context;
            this.Product = new ProductRepository(this.Context);
        }

        public IProductRepository Product { get; private set; }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
