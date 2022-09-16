using AutoMapper;
using CarAPI.Core.Application.DTOS.Car;
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
    public class CarServices : GenericServices<CreateCarDTO, CarDTO, Car>,ICarServices
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;
        public CarServices(ICarRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CarDTO>> GetCarWithInclude() {

            List<Car> cars = await _repository.GetCarWithInclude();

            return _mapper.Map<List<CarDTO>>(cars);
        
        }
    }
}
