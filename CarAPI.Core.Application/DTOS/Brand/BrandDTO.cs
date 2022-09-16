using CarAPI.Core.Application.DTOS.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.DTOS.Brand
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarDTO> Cars { get; set; }
    }
}
