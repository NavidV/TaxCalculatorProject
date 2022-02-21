namespace DataService.APIProject.Models
{
    public class CongestionTax
    {
        public int Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public double Fee { get; set; }
        public int SelectedCityId { get; set; }
    }
}
