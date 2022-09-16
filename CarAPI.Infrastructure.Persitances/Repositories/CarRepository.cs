using CarAPI.Core.Application.Interfaces.Repositories;
using CarAPI.Core.Domain.Entities;
using CarAPI.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Infrastructure.Persistance.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly ApplicationContext _applicationContext;
        public CarRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Car>> GetCarWithInclude()
        {

            return await _applicationContext.Set<Car>().Include(x => x.Brand).ToListAsync();

        }
    }
}
