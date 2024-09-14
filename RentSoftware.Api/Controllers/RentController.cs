using Microsoft.AspNetCore.Mvc;
using RentSoftware.Core.Entities;
using RentSoftware.Core.Services;
using RentSoftware.Service;

namespace RentSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAllRentAsync()
        {
            var allRents = await _rentService.GetAllRentAsync();
            return Ok(allRents);
        }

        [HttpPost]
        public async Task<ActionResult<Rent>> AddRent(Rent rent)
        {
            await _rentService.AddRentAsync(rent);
            return CreatedAtAction(nameof(GetRentById), new { id = rent.RentId }, rent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRentById(int id)
        {
            var rent = await _rentService.GetRentByIdAsync(id);

            if (rent == null)
            {
                return BadRequest($"Rent with Id : {id} not found");
            }

            return Ok(rent);
        }
    }
}
