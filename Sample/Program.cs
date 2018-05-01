using System;
using System.Linq;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MyContext())
            {
                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "John Doe",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                ctx.Customers.Add(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                ctx.Customers.Update(customer);

                // Index document using document Name property
                ctx.Customers.ConfigureIndices(x => x.Name);

                // Use LINQ to query documents
                var results = ctx.Customers.Where(x => x.Name.StartsWith("Jo"));

                // Let's create an index in phone numbers (using expression). It's a multikey index
                ctx.Customers.ConfigureIndices(x => x.Phones, "$.Phones[*]");

                // and now we can query phones
                var r = ctx.Customers.FirstOrDefault(x => x.Phones.Contains("8888-5555"));
                Console.Read();
            }
        }
    }
}
