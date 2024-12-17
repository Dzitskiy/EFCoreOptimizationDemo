using AutoMapper;
using Demo.Contracts.Ticket;
using Demo.Domain;

namespace Demo.Infrastructure.ComponentRegistrar.MapProfiles;

/// <summary>
/// Профиль маппинга моделей билетов.
/// </summary>
public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<Ticket, TicketDto>(MemberList.None);
    }
}