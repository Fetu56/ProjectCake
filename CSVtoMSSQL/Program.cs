using CSVtoMSSQL.Models;
using CSVtoMSSQL.Logic;
using CSVtoMSSQL.Models.Mapping;
using CSVtoMSSQL.Logic.Results;

Console.WriteLine("Hello! Provide path for your CSV file to insert it data to SQL table.");
string? CSVfilepath = Console.ReadLine();
if (string.IsNullOrWhiteSpace(CSVfilepath) || !File.Exists(CSVfilepath)
    || !CSVfilepath.EndsWith(Consts.CSV_FILE_EXTENSION, StringComparison.CurrentCultureIgnoreCase))
{
    Console.WriteLine("Wrong file path or file extension. Closing the application...");
    Console.Read();
    return;
}

List<Cab> cabRecords = CsvHandler.ReadFromFile<Cab>(CSVfilepath, typeof(CabCsvMap));
CabSegregateDubsResult segregationResult = CabTools.SegregateDublicates(cabRecords);
CsvHandler.WriteToFile(segregationResult.Dublicates, Consts.CSV_DUBLICATES_FILE_PATH, typeof(CabCsvMap));
CabTools.ChangeTimeToUTC(segregationResult.Cabs);//We don't change time for dublicates.
await CabTools.SaveToDB(segregationResult.Cabs);
Console.WriteLine($"Operation done! Total cabs inserted in DB: {segregationResult.Cabs.Count}. Total dublicates: {segregationResult.Dublicates.Count}");
Console.Read();