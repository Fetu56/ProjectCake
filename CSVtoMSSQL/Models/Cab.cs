using System;
using System.Collections.Generic;

namespace CSVtoMSSQL.Models;

public partial class Cab
{
    public DateTime TpepPickupDatetime { get; set; }

    public DateTime TpepDropoffDatetime { get; set; }

    public byte PassengerCount { get; set; }

    public decimal TripDistance { get; set; }

    public Flag StoreAndFwdFlag { get; set; }

    public short PulocationId { get; set; }

    public short DolocationId { get; set; }

    public decimal FareAmount { get; set; }

    public decimal TipAmount { get; set; }
}