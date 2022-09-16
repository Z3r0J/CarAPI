using AutoMapper;
using CarAPI.Core.Application.DTOS.Brand;
using CarAPI.Core.Application.Interfaces.Repositories;
using CarAPI.Core.Application.Interfaces.Services;
using CarAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Services
{
    public class BrandServices : GenericServices<CreateBrandDTO, BrandDTO, Brand>,IBrandServices
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;
        public BrandServices(IBrandRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BrandDTO>> GetBrandWithInclude() {

            List<Brand> brands = await _repository.GetAllWithInclude(new() { "Cars" });

            return _mapper.Map<List<BrandDTO>>(brands);
        
        }
    }
}
