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

        public static T WriteToFile<T>()
        {
            throw new NotImplementedException();
        }
    }
}