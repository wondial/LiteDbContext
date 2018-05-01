using LiteDbContext;

namespace Sample
{
    public class MyContext : ALiteDbContext
    {
        public readonly LiteDbSet<Customer> Customers;

        public MyContext() : base("MyData.db")
        {
            Customers = new LiteDbSet<Customer>(InternalDatabase);
            Customers.ConfigureIndices(o => o.Id);
        }
    }
}
