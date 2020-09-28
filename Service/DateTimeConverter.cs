using Newtonsoft.Json.Converters;

namespace RaidPlannerClient.Service {
    public class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }

}