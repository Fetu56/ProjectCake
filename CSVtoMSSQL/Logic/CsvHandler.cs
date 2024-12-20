using System.Globalization;
using CsvHelper;

namespace CSVtoMSSQL.Logic
{
    public static class CsvHandler
    {
        public static List<T> ReadFromFile<T>(string filepath, Type? modelMap = null)
        {
            using StreamReader reader = new(filepath);
            using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
            if (modelMap is not null)
            {
                csv.Context.RegisterClassMap(modelMap);
            }

            return csv.GetRecords<T>().ToList();
        }

        public static void WriteToFile<T>(List<T> records, string pathToSave, Type? modelMap = null)
        {
            using var writer = new StreamWriter(pathToSave);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            if (modelMap is not null)
            {
                csv.Context.RegisterClassMap(modelMap);
            }

            csv.WriteRecords(records);
        }
    }
}