using Nager.Date;

namespace TaxCalculatorService.APIProject.Helpers
{
    public static class DateTimeHelper
    {
        public static bool IsBetween(TimeSpan dateToCompare, TimeSpan start, TimeSpan end)
        {
            return dateToCompare >= start && dateToCompare <= end;
        }

        public static bool IsHoliday(DateTime date)
        {
            return DateSystem.IsPublicHoliday(date, CountryCode.SE);
        }
    }
}
