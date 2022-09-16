using CarAPI.Core.Application.DTOS.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPI.Core.Application.DTOS.Car
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string PhotoUrl { get; set; }
        public int Year { get; set; }
        public int Speed { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
