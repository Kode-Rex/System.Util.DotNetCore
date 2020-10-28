using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Number;

namespace StoneAge.System.Utils.Tests.Number
{
    [TestFixture]
    public class ULongExtensionTests
    {
        [Test]
        public void Expect_Long_Value()
        {
            // arrange
            var value = 234UL;
            // act
            var actual = value.ToLong();
            // assert
            var expected = 234L;
            actual.Should().Be(expected);
        }
    }
}
