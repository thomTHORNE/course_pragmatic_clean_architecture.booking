using Application.Abstractions.Messaging;

namespace Application.Apartments.SearchApartments;

public record class SearchApartmentsQuery(
    DateOnly StartDate,
    DateOnly EndDate
) : IQuery<IReadOnlyList<ApartmentResponse>>
{ }