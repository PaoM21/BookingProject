using BookingProject.Domain.Entities;

namespace BookingProject.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task AddAsync(Reservation reservation);
        Task<Reservation> GetByIdAsync(int id);
        Task UpdateAsync(Reservation reservation);
        Task DeleteAsync(int id);
        Task<IEnumerable<Reservation>> GetAllAsync(DateTime? date = null, int? clientId = null, int? serviceId = null);
    }
}
