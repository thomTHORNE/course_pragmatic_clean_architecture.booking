using System;

namespace Booking.Domain.Users;

public interface IApartmentRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
