using CSVtoMSSQL.Models;
using CSVtoMSSQL.Logic;

Console.WriteLine("Hello! Provide path for your CSV file to insert it data to SQL table.");
string? CSVfilepath = Console.ReadLine();
if (string.IsNullOrWhiteSpace(CSVfilepath) || !File.Exists(CSVfilepath)
    || !CSVfilepath.EndsWith(Consts.CSV_FILE_EXTENSION, StringComparison.CurrentCultureIgnoreCase))
{
    Console.WriteLine("Wrong file path or file extension. Closing the application...");
    Console.Read();
    return;
}

//Because of disposed reader - we forced convert IEnumerable to List and store it in program memory. Have to be optimized dealing with bigger files.
List<Cab> cabRecords = CsvHandler.ReadFromFile<Cab>(CSVfilepath, typeof(CabCsvMap));
CabTools.ChangeTimeToUTC(cabRecords);
await CabTools.SaveToDB(cabRecords);