using CSVtoMSSQL.Logic.Results;
using CSVtoMSSQL.Models;
using EFCore.BulkExtensions;

namespace CSVtoMSSQL.Logic
{
    public static class CabTools
    {
        public static void ChangeTimeToUTC(List<Cab> cabs)
        {
            TimeZoneInfo originalTimeZone = TimeZoneInfo.FindSystemTimeZoneById(Consts.ORIGINAL_TIME_ZONE_NAME);
            cabs.ForEach(cab =>
            {
                cab.TpepDropoffDatetime = TimeZoneInfo.ConvertTimeToUtc(cab.TpepDropoffDatetime, originalTimeZone);
                cab.TpepPickupDatetime = TimeZoneInfo.ConvertTimeToUtc(cab.TpepPickupDatetime, originalTimeZone);
            });
        }

        public static CabSegregateDubsResult SegregateDublicates(List<Cab> cabs)
        {
            throw new NotImplementedException();
        }

        public static async Task SaveToDB(List<Cab> cabs)
        {
            using CsvtoSqlContext dbContext = new();
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            await dbContext.BulkInsertAsync(cabs);
            await transaction.CommitAsync();
        }
    }
}