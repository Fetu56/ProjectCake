using CsvHelper.Configuration;

namespace CSVtoMSSQL.Models
{
    public class CabCsvMap : ClassMap<Cab>
    {
        public CabCsvMap()
        {
            Map(m => m.TpepPickupDatetime).Name("tpep_pickup_datetime");
            Map(m => m.TpepDropoffDatetime).Name("tpep_dropoff_datetime");
            Map(m => m.PassengerCount).Name("passenger_count");
            Map(m => m.TripDistance).Name("trip_distance");
            Map(m => m.PULocationId).Name("PULocationID");
            Map(m => m.DOLocationId).Name("DOLocationID");
            Map(m => m.FareAmount).Name("fare_amount");
            Map(m => m.TipAmount).Name("tip_amount");
            Map(m => m.StoreAndFwdFlag).Name("store_and_fwd_flag").TypeConverter<FlagConverter>();
        }
    }
}