using System;
using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Time;

namespace StoneAge.System.Utils.Tests.Time
{
    [TestFixture]
    public class UtcUtilsTests
    {
        [TestFixture]
        class Parse_As_Utc_Then_Add_Current_Timezone_Offset
        {
            [Test]
            public void Given_Date_In_Daylight_Savings_ShouldReturnUtcTimeWithTimeZoneOffsetAdded()
            {
                //---------------Arrange-------------------
                var input = "2018-04-01 04:00:00";
                var parsedDateTime = DateTime.Parse(input);
                //---------------Act----------------------
                var actual = input.Parse_As_Utc_Then_Add_Current_Timezone_Offset();
                //---------------Assert-----------------------
                var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(parsedDateTime).Hours * -1;
                var hour = 4 + timeZoneOffset;
                var expected = DateTime.Parse($"2018-04-01 {hour:00}:00:00");
                actual.Should().Be(expected);
                actual.Should().Be(expected);
            }

            [Test]
            public void Given_Date_Outside_Daylight_Savings_ShouldReturnUtcTimeWithTimeZoneOffsetAdded()
            {
                //---------------Arrange-------------------
                var input = "2018-12-01 04:00:00";
                var parsedDateTime = DateTime.Parse(input);
                //---------------Act----------------------
                var actual = input.Parse_As_Utc_Then_Add_Current_Timezone_Offset();
                //---------------Assert-----------------------
                var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(parsedDateTime).Hours * -1;
                var hour = 4 + timeZoneOffset;
                var expected = DateTime.Parse($"2018-12-01 {hour:00}:00:00");
                actual.Should().Be(expected);
                actual.Should().Be(expected);
            }
        }
    }
}
