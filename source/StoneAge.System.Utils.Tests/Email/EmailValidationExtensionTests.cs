using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Email;

namespace StoneAge.System.Utils.Tests.Email
{
    [TestFixture]
    public class EmailValidationExtensionTests
    {
        [Test]
        public void Is_Valid_Email_WhenValidEmail_ShouldReturnTrue()
        {
            //---------------Arrange------------------
            var input = "t@bizvoip.co.za";
            //---------------Act----------------------
            var actual = input.Is_Valid_Email();
            //---------------Assert-------------------
            actual.Should().BeTrue();
        }

        [Test]
        public void Is_Valid_Email_WhenInvalidEmail_ShouldReturnFalse()
        {
            //---------------Arrange------------------
            var input = "t@foo";
            //---------------Act----------------------
            var actual = input.Is_Valid_Email();
            //---------------Assert-------------------
            actual.Should().BeFalse();
        }
    }
}
