using CSVtoMSSQL.Models;

namespace CSVtoMSSQL.Logic.Results
{
    public record CabSegregateDubsResult(List<Cab> Cabs, List<Cab> Dublicates);
}