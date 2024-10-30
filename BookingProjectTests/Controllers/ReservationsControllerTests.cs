using BookingProject.API.Controllers;
using BookingProject.Application.Services;
using BookingProject.Domain.Entities;
using BookingProject.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class ReservationsControllerTests
{
    private readonly Mock<IReservationRepository> _mockReservationRepository;
    private readonly ReservationsController _controller;
    private readonly ReservationService _reservationService;

    public ReservationsControllerTests()
    {
        _mockReservationRepository = new Mock<IReservationRepository>();

        _reservationService = new ReservationService(_mockReservationRepository.Object);

        _controller = new ReservationsController(_reservationService);
    }

    [Fact]
    public async Task CreateReservation_ShouldReturnCreatedResult()
    {
        // Arrange
        var reservation = new Reservation { Id = 1, ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now };

        _mockReservationRepository.Setup(s => s.AddAsync(reservation)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.CreateReservation(reservation);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(reservation.Id, actionResult.RouteValues["id"]);
        _mockReservationRepository.Verify(s => s.AddAsync(reservation), Times.Once);
    }

    [Fact]
    public async Task GetReservation_ShouldReturnOkResult()
    {
        // Arrange
        var reservation = new Reservation { Id = 1, ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now };
        _mockReservationRepository.Setup(s => s.GetByIdAsync(reservation.Id)).ReturnsAsync(reservation);

        // Act
        var result = await _controller.GetReservation(reservation.Id);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(reservation, actionResult.Value);
    }

    [Fact]
    public async Task UpdateReservation_ShouldReturnNoContent()
    {
        // Arrange
        var reservation = new Reservation { Id = 1, ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now };

        _mockReservationRepository.Setup(s => s.UpdateAsync(reservation)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateReservation(reservation.Id, reservation);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _mockReservationRepository.Verify(s => s.UpdateAsync(reservation), Times.Once);
    }

    [Fact]
    public async Task CancelReservation_ShouldReturnNoContent()
    {
        // Arrange
        int reservationId = 1;

        _mockReservationRepository.Setup(s => s.DeleteAsync(reservationId)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.CancelReservation(reservationId);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _mockReservationRepository.Verify(s => s.DeleteAsync(reservationId), Times.Once);
    }

    [Fact]
    public async Task GetReservations_ShouldReturnOkResult()
    {
        // Arrange
        var reservations = new List<Reservation>
        {
            new Reservation { Id = 1, ClientId = 1, ServiceId = 1, ReservationDate = DateTime.Now },
            new Reservation { Id = 2, ClientId = 2, ServiceId = 2, ReservationDate = DateTime.Now }
        };

        _mockReservationRepository.Setup(s => s.GetAllAsync(null, null, null)).ReturnsAsync(reservations);

        // Act
        var result = await _controller.GetReservations(null, null, null);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(reservations, actionResult.Value);
    }
}