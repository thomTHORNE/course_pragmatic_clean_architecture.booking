using System;
using Application.Abstractions.Email;
using Domain.Bookings;
using Domain.Bookings.Events;
using Domain.Users;
using MediatR;

namespace Application.Bookings.ReserveBooking;

// Upon reserving a booking, the user must receive an email notifying
// them of successful booking reservation.
internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(IBookingRepository bookingRepository, IUserRepository userRepository, IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        // Booking was made by a specific user.
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId);
        if (booking is null)
        {
            return;
        }

        // We can get more data about a user by using the user's id from 
        // the booking. 
        var user = await _userRepository.GetByIdAsync(booking.UserId);
        if (user is null)
        {
            return;
        }

        await _emailService.SendAsync(
            user.Email,
            "Booking reserved!",
            "You have 10 minutes to confirm this booking."
        );
    }
}
