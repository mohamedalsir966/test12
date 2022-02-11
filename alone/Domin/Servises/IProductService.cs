using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alone.Domin.Servises
{
    public interface IProductService
    {
        Task<IList<Product>> ListAsync();
    }
}
