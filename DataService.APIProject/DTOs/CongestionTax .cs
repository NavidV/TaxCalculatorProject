namespace DataService.APIProject.DTOs
{
    public class TaxFeeDto
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public double Fee { get; set; }
        public int SelectedCityId { get; set; }
    }
}
