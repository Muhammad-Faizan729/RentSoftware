using Microsoft.AspNetCore.Mvc;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;

namespace RentSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCarAsync()
        {
            var allCars = await _carService.GetAllCarAsync();
            return Ok(allCars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car == null)
            {
                return BadRequest($"Car with Id : {id} not found");
            }

            return Ok(car);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> UpdateCar(int id, Car car)
        {
            var existingCar = await _carService.GetCarByIdAsync(id);

            if (existingCar == null)
            {
                return BadRequest($"Car with Id : {id} not found");
            }

            existingCar.CarModel = car.CarModel;

            await _carService.UpdateCarAsync(existingCar);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            await _carService.DeleteCarAsync(car);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            await _carService.AddCarAsync(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.CarId }, car);
        }
    }
}
