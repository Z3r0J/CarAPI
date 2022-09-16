using CarAPI.Core.Application.DTOS.Car;
using CarAPI.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarServices _carServices;
        public CarController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get() {

            try
            {
                var Cars = await _carServices.GetCarWithInclude();

                if (Cars.Count == 0 || Cars == null)
                {
                    return NotFound();
                }


                return Ok(Cars);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id) {

            try
            {
                var Cars = await _carServices.GetCarWithInclude();

                var CarById = Cars.FirstOrDefault(c => c.Id == id);

                if (CarById == null)
                {
                    return NotFound();
                }

                return Ok(CarById);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateCarDTO dTO) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _carServices.Add(dTO);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(CreateCarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id,CreateCarDTO dTO) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                dTO.Id = id;

                await _carServices.Update(dTO,id);

                return Ok(dTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {

                await _carServices.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
