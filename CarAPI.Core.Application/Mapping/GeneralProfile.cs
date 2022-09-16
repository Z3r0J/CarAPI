using AutoMapper;
using CarAPI.Core.Application.DTOS.Brand;
using CarAPI.Core.Application.DTOS.Car;
using CarAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Brand, CreateBrandDTO>()
                .ReverseMap()
                .ForMember(b=>b.Cars,option=>option.Ignore());

            CreateMap<Brand, BrandDTO>()
                .ReverseMap();

            CreateMap<Car, CreateCarDTO>()
                .ReverseMap()
                .ForMember(c=>c.Brand,option=>option.Ignore());

            CreateMap<Car, CarDTO>()
                .ForMember(cdt=>cdt.BrandName,option=>option.MapFrom(c=>c.Brand.Name))
                .ReverseMap();
        }
    }
}
