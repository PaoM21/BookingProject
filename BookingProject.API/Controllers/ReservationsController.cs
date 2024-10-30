using BookingProject.Application.Services;
using BookingProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            await _reservationService.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest("ID de reserva no coincide.");
            }

            await _reservationService.UpdateReservationAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations([FromQuery] DateTime? date, [FromQuery] int? clientId, [FromQuery] int? serviceId)
        {
            var reservations = await _reservationService.GetReservationsAsync(date, clientId, serviceId);
            return Ok(reservations);
        }
    }
}
