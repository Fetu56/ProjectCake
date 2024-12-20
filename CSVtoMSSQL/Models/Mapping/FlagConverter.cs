using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace CSVtoMSSQL.Models.Mapping
{
    public class FlagConverter : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            if (text?.Length != 1 || !Enum.IsDefined(typeof(NoYesFlag), (int)text[0]))
            {
                throw new InvalidCastException("Wrong data in flag column.");
            }

            return (NoYesFlag)text[0];
        }
    }
}