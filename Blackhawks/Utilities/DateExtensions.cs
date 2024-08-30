namespace Blackhawks.Utilities;

public static class DateExtensions
{
    public static int GetCurrentAge(this DateOnly dateOfBirth)
    {
        var today = DateTime.Today.Date;
        return (DateTime.Today.Year - dateOfBirth.Year) + GetMonthOffset(dateOfBirth, today);
    }

    private static int GetMonthOffset(DateOnly date, DateTime currentDate)
    {
        if (currentDate.Month > date.Month)
        {
            return 0;
        }

        if (currentDate.Month == date.Month & currentDate.Day >= date.Day)
        {
            return 0;
        }

        return -1;
    }
}