using CarAPI.Core.Application.DTOS.Car;
using CarAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Interfaces.Services
{
    public interface ICarServices : IGenericServices<CreateCarDTO,CarDTO,Car>
    {
        Task<List<CarDTO>> GetCarWithInclude();
    }
}
