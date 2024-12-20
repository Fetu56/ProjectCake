using CSVtoMSSQL.Logic.Results;
using CSVtoMSSQL.Models;
using EFCore.BulkExtensions;

namespace CSVtoMSSQL.Logic
{
    public static class CabTools
    {
        public static void ChangeTimeToUTC(List<Cab> cabs, string originalTimeZoneName = Consts.ORIGINAL_TIME_ZONE_NAME)
        {
            TimeZoneInfo originalTimeZone = TimeZoneInfo.FindSystemTimeZoneById(originalTimeZoneName);
            cabs.ForEach(cab =>
            {
                cab.TpepDropoffDatetime = TimeZoneInfo.ConvertTimeToUtc(cab.TpepDropoffDatetime, originalTimeZone);
                cab.TpepPickupDatetime = TimeZoneInfo.ConvertTimeToUtc(cab.TpepPickupDatetime, originalTimeZone);
            });
        }

        public static CabSegregateDubsResult SegregateDublicates(List<Cab> cabs)
        {
            List<Cab> dublicates = cabs.GroupBy(cab => (cab.TpepDropoffDatetime, cab.TpepPickupDatetime, cab.PassengerCount))
                  .Where(cab => cab.Count() > 1)
                  .SelectMany(cab => cab).ToList();
            return new(cabs.Except(dublicates).ToList(), dublicates);
        }

        public static async Task SaveToDB(List<Cab> cabs)
        {
            using MainContext dbContext = new();
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            await dbContext.BulkInsertAsync(cabs);
            await transaction.CommitAsync();
        }
    }
}