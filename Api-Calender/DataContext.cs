using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;

namespace Api_Calender
{
    public class DataContext
    {


        public List<Event> events { get; set; }

        public DataContext()
        {
            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                events = csv.GetRecords<Event>().ToList();
            }
        }
    }
}
