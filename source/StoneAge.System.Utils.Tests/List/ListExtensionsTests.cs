using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace StoneAge.System.Utils.Tests.Json
{
    [TestFixture]
    public class ListExtensionsTests
    {
        [Test]
        public void Split_List_When_100_Items_Split_By_20_Expect_5_Chunks()
        {
            //---------------Set up test pack-------------------
            var input = Enumerable.Range(0, 100).ToList();
            //---------------Execute Test ----------------------
            var result = input.Split_List(20);
            //---------------Test Result -----------------------
            var expected = 5;
            result.Count().Should().Be(expected);
        }

        [Test]
        public void Split_List_When_100_Items_Split_By_Default_10_Expect_10_Chunks()
        {
            //---------------Set up test pack-------------------
            var input = Enumerable.Range(0, 100).ToList();
            //---------------Execute Test ----------------------
            var result = input.Split_List();
            //---------------Test Result -----------------------
            var expected = 10;
            result.Count().Should().Be(expected);
        }
    }
}
