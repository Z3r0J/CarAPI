using CarAPI.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Interfaces.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<List<Car>> GetCarWithInclude();
    }
}