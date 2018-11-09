using System;
using NUnit.Framework;
using StoneAge.System.Utils.Time;

namespace StoneAge.System.Utils.Tests.Time
{
    [TestFixture]
    public class UtcNowTests
    {
        [Test]
        public void Now_ShouldReturnUtcOffsetTime()
        {
            //---------------Arrange-------------------
            var sut = new UtcNow();
            //---------------Act----------------------
            var actual = sut.Now();
            //---------------Assert-----------------------
            var expected = DateTime.Now.ToUniversalTime();
            Assert.AreEqual(expected.ToString("yyyy-MM-dd hh:mm:ss"), actual.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
