using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Number;

namespace StoneAge.System.Utils.Tests.Number
{
    [TestFixture]
    public class UIntExtensionTests
    {
        [Test]
        public void Expect_Int_Value()
        {
            // arrange
            var value = 234U;
            // act
            var actual = value.ToInt();
            // assert
            var expected = 234;
            actual.Should().Be(expected);
        }
    }
}
