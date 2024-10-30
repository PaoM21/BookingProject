using BookingProject.Domain.Entities;
using BookingProject.Domain.Repositories;

namespace BookingProject.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.AddAsync(reservation);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteReservationAsync(int id)
        {
            await _reservationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync(DateTime? date, int? clientId, int? serviceId)
        {
            return await _reservationRepository.GetAllAsync(date, clientId, serviceId);
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }
    }
}
