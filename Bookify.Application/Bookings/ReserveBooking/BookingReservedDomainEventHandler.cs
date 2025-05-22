using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IEmailService emailService)
    : INotificationHandler<BookingReserveDomainEvent>
{
    public async Task Handle(BookingReserveDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
        
        if (booking is null)
        {
            return;
        }
        
        var user = await userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        
        if (user is null)
        {
            return;
        }
        
        await emailService.SendAsync(user.Email, "Booking Reserved!",
            "You have 10 minutes to confirm your booking. ");
    }
}