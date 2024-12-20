using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace CSVtoMSSQL.Models
{
    public class FlagConverter : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            if (text?.Length != 1 || !Enum.IsDefined(typeof(Flag), (int)text[0]))
            {
                throw new InvalidCastException("Wrong data in flag column.");
            }

            return (Flag)text[0];
        }
    }
}