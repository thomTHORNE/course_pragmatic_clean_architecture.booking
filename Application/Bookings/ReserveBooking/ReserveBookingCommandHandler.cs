using System;
using Application.Abstractions.Messaging;
using Booking.Domain.Abstractions;
using Booking.Domain.Bookings;
using Booking.Domain.Users;

namespace Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;
    
}
