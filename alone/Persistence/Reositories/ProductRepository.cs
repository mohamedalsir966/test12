using alone.Domin;
using alone.Domin.Repositories;
using alone.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alone.Persistence.Reositories
{
    public class ProductRepository : BaseRepository, IproductRepositories
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IList<Product>> ListAsync()
        {
            var Productslist = await _context.Products.ToListAsync();
            return Productslist;
        }
    }
}
