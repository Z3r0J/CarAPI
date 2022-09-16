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
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly ApplicationContext _applicationContext;
        public BrandRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
