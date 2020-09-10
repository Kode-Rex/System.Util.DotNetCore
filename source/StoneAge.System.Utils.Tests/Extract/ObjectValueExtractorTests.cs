using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Extract;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoneAge.System.Utils.Tests.Extract
{
    [TestFixture]
    public class ObjectValueExtractorTests
    {
        // todo : test default
        [Test]
        public void When_Primative_Exist_Expect_Value()
        {
            // arrange
            var testObject = new TestObject(5, new List<string> { "abc", "def" });
            // act
            var actual = testObject.ExtractField<int>("_value1");
            // assert
            var expected = 5;
            actual.Should().Be(expected);
        }

        [Test]
        public void When_Primative_Does_Not_Exist_Expect_Default_Value()
        {
            // arrange
            var testObject = new TestObject(5, new List<string> { "abc", "def" });
            // act
            var actual = testObject.ExtractField<int>("_value1992349");
            // assert
            var expected = 0;
            actual.Should().Be(expected);
        }

        [Test]
        public void When_Object_Exist_Expect_Value()
        {
            // arrange
            var testObject = new TestObject(5, new List<string> { "abc", "def" });
            // act
            var actual = testObject.ExtractField<List<string>>("_value2");
            // assert
            var expected = new List<string> { "abc", "def" };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void When_OBject_Does_Not_Exist_Expect_Null()
        {
            // arrange
            var testObject = new TestObject(5, new List<string> { "abc", "def" });
            // act
            var actual = testObject.ExtractField<List<string>>("_value1992349");
            // assert
            actual.Should().BeNull();
        }
    }

    public class TestObject
    {
        private int _value1;
        private List<string> _value2;

        public TestObject(int value1, List<string> value2)
        {
            _value1 = value1;
            _value2 = value2;
        }
    }
}
