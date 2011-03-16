using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubProductRepository : ProductRepository
    {
        public IEnumerable<Product> get_the_products_for(Department department)
        {
            return Enumerable.Range(0, 10).Select(x => new Product());
        }
    }
}