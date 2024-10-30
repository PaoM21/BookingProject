using BookingProject.Domain.Entities;
using BookingProject.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingProject.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BookingContext _context;

        public ReservationRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await GetByIdAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync(DateTime? date, int? clientId, int? serviceId)
        {
            return await _context.Reservations.ToListAsync();
        }
    }
}
