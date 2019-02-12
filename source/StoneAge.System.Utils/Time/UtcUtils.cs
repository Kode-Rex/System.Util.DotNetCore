using System;

namespace StoneAge.System.Utils.Time
{
    public static class UtcUtils
    {
        public static DateTime Parse_As_Utc_Then_Add_Current_Timezone_Offset(this string dateTimeString)
        {
            var utcOffsetHours = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Hours * -1;
            return DateTime.SpecifyKind(DateTime.Parse(dateTimeString), DateTimeKind.Utc).AddHours(utcOffsetHours);
        }
    }
}