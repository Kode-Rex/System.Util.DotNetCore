using System;

namespace StoneAge.System.Utils.Time
{
    public static class UtcUtils
    {
        public static DateTime Parse_As_Utc_Then_Add_Current_Timezone_Offset(this string dateTimeString)
        {
            var dateTime = DateTime.Parse(dateTimeString);
            var utcOffsetHours = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Hours * -1;
            
            if(TimeZoneInfo.Local.IsDaylightSavingTime(dateTime))
            {
                utcOffsetHours -= 1;
            }

            var utcTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            return utcTime.AddHours(utcOffsetHours);
        }
    }
}