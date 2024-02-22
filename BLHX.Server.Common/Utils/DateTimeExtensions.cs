namespace BLHX.Server.Common.Utils
{
    public static class DateTimeExtensions
    {
        public static int GetWeekOfMonth(this DateTime date)
        {
            int dayOfMonth = date.Day;
            DateTime firstDayOfMonth = new(date.Year, date.Month, 1);
            DayOfWeek firstDayOfWeek = firstDayOfMonth.DayOfWeek;
            int offset = (dayOfMonth + (int)firstDayOfWeek - 1) / 7;
            return offset + 1;
        }

        public static double GetSecondsPassed(this DateTime date)
        {
            return (DateTime.Now - date).TotalSeconds;
        }
    }
}
