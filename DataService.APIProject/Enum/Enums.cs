using System.Text.Json.Serialization;

namespace DataService.APIProject.Helpers
{
    public static class Enums
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum VehiclesEnum
        {
            Car = 1,
            Bus = 2,
            Motorbike = 3,
            Emergency = 4,
            Diplomat = 5,
            Foreign = 6,
            Military = 7
        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum CitiesEnum
        {
            Gothenburg = 1,
        }
    }
}
