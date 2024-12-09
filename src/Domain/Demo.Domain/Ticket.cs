namespace Demo.Domain;

/// <summary>
/// Tickets
/// </summary>
public partial class Ticket
{
    /// <summary>
    /// Ticket number
    /// </summary>
    public string TicketNo { get; set; }

    /// <summary>
    /// Booking number
    /// </summary>
    public string BookRef { get; set; }

    /// <summary>
    /// Passenger ID
    /// </summary>
    public string PassengerId { get; set; }

    /// <summary>
    /// Passenger name
    /// </summary>
    public string PassengerName { get; set; }

    /// <summary>
    /// Passenger contact information
    /// </summary>
    public string ContactData { get; set; }

    public virtual Booking BookRefNavigation { get; set; }

    public virtual ICollection<TicketFlight> TicketFlights { get; set; } = new List<TicketFlight>();
}
