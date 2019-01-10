using System;
using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Time;

namespace StoneAge.System.Utils.Tests.Time
{
    [TestFixture]
    public class UtcParserTests
    {
        [Test]
        public void Parse_As_Utc_Then_Add_Current_Timezone_Offset_ShouldReturnUtcTimeWithTimeZoneOffsetAdded()
        {
            //---------------Arrange-------------------
            var input = "2018-04-01 04:00:00";
            //---------------Act----------------------
            var actual = input.Parse_As_Utc_Then_Add_Current_Timezone_Offset();
            //---------------Assert-----------------------
            var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Hours * -1;
            var hour = 4 + timeZoneOffset;
            var expected = DateTime.Parse($"2018-04-01 {hour:00}:00:00");
            actual.Should().Be(expected);
        }
    }
}
