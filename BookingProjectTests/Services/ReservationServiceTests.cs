using BookingProject.Application.Services;
using BookingProject.Domain.Entities;
using BookingProject.Domain.Repositories;
using BookingProject.Infrastructure;
using BookingProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class ReservationServiceTests
{
    private readonly BookingContext _context;
    private readonly IReservationRepository _reservationRepository;
    private readonly ReservationService _service;

    public ReservationServiceTests()
    {
        var options = new DbContextOptionsBuilder<BookingContext>()
            .UseInMemoryDatabase(databaseName: "BookingTestDb")
            .Options;

        _context = new BookingContext(options);
        _reservationRepository = new ReservationRepository(_context);
        _service = new ReservationService(_reservationRepository);
    }

    [Fact]
    public async Task CreateReservationAsync_ShouldAddReservation()
    {
        // Arrange
        var reservation = new Reservation { ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now };

        // Act
        await _service.CreateReservationAsync(reservation);

        // Assert
        var result = await _context.Reservations.FindAsync(reservation.Id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetReservationByIdAsync_ShouldReturnReservation()
    {
        // Arrange
        var reservation = new Reservation { ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now };
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetReservationByIdAsync(reservation.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(reservation.ClientId, result.ClientId);
    }

    [Fact]
    public async Task UpdateReservationAsync_ShouldModifyReservation()
    {
        // Arrange
        var reservation = new Reservation { ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now };
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        reservation.ServiceId = 2;

        // Act
        await _service.UpdateReservationAsync(reservation);

        // Assert
        var updatedReservation = await _context.Reservations.FindAsync(reservation.Id);
        Assert.Equal(2, updatedReservation.ServiceId);
    }

    [Fact]
    public async Task DeleteReservationAsync_ShouldRemoveReservation()
    {
        // Arrange
        var reservation = new Reservation { ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now };
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();

        // Act
        await _service.DeleteReservationAsync(reservation.Id);

        // Assert
        var result = await _context.Reservations.FindAsync(reservation.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllReservations()
    {
        // Arrange
        await _context.Reservations.AddAsync(new Reservation { ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now });
        await _context.Reservations.AddAsync(new Reservation { ClientId = 2, ServiceId = 2, ReservationDate = DateTime.Now });
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetReservationsAsync(null, null, null);

        // Assert
        Assert.Equal(2, result.Count());
    }
}