using CarAPI.Core.Application.Interfaces.Services;
using CarAPI.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Infrastructure.Persistance.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        private readonly ApplicationContext _applicationContext;

        public GenericRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public virtual async Task<Entity> Add(Entity entity) {

            await _applicationContext.AddAsync(entity);
            await _applicationContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<List<Entity>> GetAll() {

            return await _applicationContext.Set<Entity>().ToListAsync();
        }

        public virtual async Task<Entity> GetById(int id) {

            return await _applicationContext.Set<Entity>().FindAsync(id);

        }

        public virtual async Task<List<Entity>> GetAllWithInclude(List<string> properties) {

            var query = _applicationContext.Set<Entity>().AsQueryable();


            foreach (var prop in properties)
            {
                query = query.Include(prop);
            }

            return await query.ToListAsync();
        
        }

        public virtual async Task Update(Entity entity, int id) {

            var entry = await _applicationContext.Set<Entity>().FindAsync(id);

            _applicationContext.Entry(entry).CurrentValues.SetValues(entity);

            await _applicationContext.SaveChangesAsync();
        }

        public virtual async Task Delete(Entity entity) {

            _applicationContext.Set<Entity>().Remove(entity);

            await _applicationContext.SaveChangesAsync();

        }

    }
}
