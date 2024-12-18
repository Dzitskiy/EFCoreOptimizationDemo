using Demo.Application.AppServices.Contexts.Ticket.Repositories;
using Demo.Application.AppServices.Enums;
using Demo.Contracts.Ticket;

namespace Demo.Application.AppServices.Contexts.Ticket.Services;

/// <inheritdoc />
public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;

    /// <summary>
    /// c-tor <see cref="TicketService"/>
    /// </summary>
    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public Task<TicketDto[]> GetByPassengerIdAsync(string passengerId, CancellationToken cancellationToken)
    {
        return _repository.GetByPassengerIdAsync(passengerId, cancellationToken);
    }

    /// <inheritdoc />
    public Task<TicketDto[]> GetByPassengerNameAsync(string passengerName, StringCompareType compareType,
        CancellationToken cancellationToken)
    {
        switch(compareType)
        {
            case StringCompareType.Default:
                return _repository.GetByPassengerNameAsync(passengerName, cancellationToken);

            case StringCompareType.Lower:
                return _repository.GetByPassengerNameLowerAsync(passengerName, cancellationToken);
                
            case StringCompareType.ILike:
                return _repository.GetByPassengerNameILikeAsync(passengerName, cancellationToken);

            case StringCompareType.Collate:
                return _repository.GetByPassengerNameCollateAsync(passengerName, cancellationToken);
        }

        throw new ArgumentOutOfRangeException(nameof(compareType), compareType, null);
    }

    /// <inheritdoc />
    public Task<TicketDto[]> GetStartsWithPassengerNameAsync(string passengerName, StringCompareType compareType,
        CancellationToken cancellationToken)
    {
        switch (compareType)
        {
            case StringCompareType.Default:
                return _repository.GetStartsPassengerNameAsync(passengerName, cancellationToken);

            case StringCompareType.Lower:
                return _repository.GetStartsPassengerNameLowerAsync(passengerName, cancellationToken);

            case StringCompareType.ILike:
                return _repository.GetStartsPassengerNameILikeAsync(passengerName, cancellationToken);
        }

        throw new ArgumentOutOfRangeException(nameof(compareType), compareType, null);
    }
}