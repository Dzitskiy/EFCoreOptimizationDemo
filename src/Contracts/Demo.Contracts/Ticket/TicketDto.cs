namespace Demo.Contracts.Ticket;

/// <summary>
/// Информация о билете.
/// </summary>
public class TicketDto
{
    /// <summary>
    /// Номер билета.
    /// </summary>
    public string TicketNo { get; set; }

    /// <summary>
    /// Идентификационные данные пассажира (номер документа)
    /// </summary>
    public string PassengerId { get; set; }

    /// <summary>
    /// Полное имя пассажира.
    /// </summary>
    public string PassengerName { get; set; }
}