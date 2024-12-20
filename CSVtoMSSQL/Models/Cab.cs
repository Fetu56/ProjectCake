namespace CSVtoMSSQL.Models;

public partial class Cab
{
    public DateTime TpepPickupDatetime { get; set; }

    public DateTime TpepDropoffDatetime { get; set; }

    public byte? PassengerCount { get; set; }

    public decimal TripDistance { get; set; }

    public Flag? StoreAndFwdFlag { get; set; }

    public short PULocationId { get; set; }

    public short DOLocationId { get; set; }

    public decimal FareAmount { get; set; }

    public decimal TipAmount { get; set; }
}