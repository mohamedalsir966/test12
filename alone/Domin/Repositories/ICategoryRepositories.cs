using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alone.Domin.Repositories
{
    public interface ICategoryRepositories
    {
        Task<IList<Category>> ListAsync();
        Task<Category> SaveAsync(Category categor);
        Task AddAsync1(Category category);
         Task<Category> FindByIdAsync(int id);
        void UpdateAsyncalsir(Category category);
        void Remove(Category category);

    }
}
