using AutoMapper;
using CarAPI.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Services
{
    public class GenericServices<DTOCreate, DTO, Entity> : IGenericServices<DTOCreate, DTO,Entity> 
        where DTOCreate : class
        where DTO : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericServices(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async virtual Task<DTOCreate> Add(DTOCreate dto)
        {

            Entity entity = _mapper.Map<Entity>(dto);

            entity = await _repository.Add(entity);

            return _mapper.Map<DTOCreate>(entity);

        }

        public async virtual Task<DTOCreate> GetById(int id)
        {

            Entity entity = await _repository.GetById(id);

            return _mapper.Map<DTOCreate>(entity);
        }

        public async virtual Task<List<DTO>> GetAll()
        {

            List<Entity> entities = await _repository.GetAll();

            return _mapper.Map<List<DTO>>(entities);

        }

        public async virtual Task Update(DTOCreate dto, int id)
        {

            Entity entity = _mapper.Map<Entity>(dto);

            await _repository.Update(entity, id);
        }

        public async virtual Task Delete(int id)
        {

            Entity entity = await _repository.GetById(id);

            await _repository.Delete(entity);

        }
    }
}
