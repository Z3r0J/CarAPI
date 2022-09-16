using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class 
    {
        Task<Entity> Add(Entity entity);
        Task<List<Entity>> GetAll();
        Task<Entity> GetById(int id);
        Task<List<Entity>> GetAllWithInclude(List<string> properties);
        Task Update(Entity entity, int id);
        Task Delete(Entity entity);
    }
}
