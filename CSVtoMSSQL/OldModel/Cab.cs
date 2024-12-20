using System.ComponentModel.DataAnnotations.Schema;
using CSVtoMSSQL.Models;

namespace CSVtoMSSQL.Model
{
    public class Cab
    {
        [Column("VendorID")]
        public int VendorID { get; set; }

        [Column("tpep_pickup_datetime")]
        public DateTime TpepPickupDatetime { get; set; }

        [Column("tpep_dropoff_datetime")]
        public DateTime TpepDropoffDatetime { get; set; }

        [Column("passenger_count")]
        public int PassengerCount { get; set; }

        [Column("trip_distance")]
        public double TripDistance { get; set; }

        [Column("RatecodeID")]
        public int RatecodeID { get; set; }

        [Column("store_and_fwd_flag")]
        public Flag StoreAndFwd { get; set; }

        [Column("PULocationID")]
        public int PULocationID { get; set; }

        [Column("DOLocationID")]
        public int DOLocationID { get; set; }

        [Column("payment_type")]
        public int PaymentType { get; set; }

        [Column("fare_amount")]
        public int FareAmount { get; set; }

        [Column("extra")]
        public int Extra { get; set; }

        [Column("mta_tax")]
        public double MtaTax { get; set; }

        [Column("tip_amount")]
        public double TipAmount { get; set; }

        [Column("tolls_amount")]
        public int TollsAmount { get; set; }

        [Column("improvement_surcharge")]
        public double ImprovementSurcharge { get; set; }

        [Column("total_amount")]
        public double TotalAmount { get; set; }

        [Column("congestion_surcharge")]
        public double CongestionSurcharge { get; set; }
    }
}