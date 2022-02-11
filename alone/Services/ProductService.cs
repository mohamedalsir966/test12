using alone.Domin;
using alone.Domin.Repositories;
using alone.Domin.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alone.Services
{
    public class ProductService : IProductService
    {
        private readonly IproductRepositories _productRepositories;
        public ProductService(IproductRepositories productRepositories)
        {
            _productRepositories = productRepositories;

        }
        public Task<IList<Product>> ListAsync()
        {
            var c = _productRepositories.ListAsync();
            return c;
        }
    }
}
