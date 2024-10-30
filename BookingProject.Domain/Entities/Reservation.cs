namespace BookingProject.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
