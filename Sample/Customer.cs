using LiteDbContext;

namespace Sample
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }
}
