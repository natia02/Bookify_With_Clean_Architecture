using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings;

public static class BookingErrors
{
    public static Error NotFound => new("Booking.NotFound", "Booking not found");
    public static Error Overlap => new("Booking.Overlap", "Booking overlaps with another existing booking");
    public static Error NotReserved => new("Booking.NotReserved", "Booking is not reserved");
    public static Error NotConfirmed => new("Booking.NotConfirmed", "Booking is not confirmed");
    public static Error AlreadyStarted => new("Booking.AlreadyStarted", "Booking has already started");
}