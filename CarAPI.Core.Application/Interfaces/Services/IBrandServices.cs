using CarAPI.Core.Application.DTOS.Brand;
using CarAPI.Core.Application.Interfaces.Services;
using CarAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Interfaces.Services
{
    public interface IBrandServices : IGenericServices<CreateBrandDTO,BrandDTO,Brand>
    {
        Task<List<BrandDTO>> GetBrandWithInclude();
    }
}
