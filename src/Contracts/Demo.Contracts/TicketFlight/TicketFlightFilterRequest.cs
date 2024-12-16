namespace Demo.Contracts.TicketFlight;

/// <summary>
/// Параметры поиска перелётов.
/// </summary>
public class TicketFlightFilterRequest
{
    /// <summary>
    /// Идентификатор рейса.
    /// </summary>
    public int? FlightId { get; set; }

    /// <summary>
    /// Тариф.
    /// </summary>
    [Obsolete("?")]
    // todo если использовать в примере: покрывающий индекс? регнез поиск? или убрать вообще?
    public string Fare { get; set; }

    /// <summary>
    /// Номер билета.
    /// </summary>
    public string TicketNo { get; set; }
}