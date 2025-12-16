using System;

namespace Booking.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Booking.Domain.Users.Email recipient, string subject, string body);
}
