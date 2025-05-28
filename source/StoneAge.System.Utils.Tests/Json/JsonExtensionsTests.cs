using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Json;

namespace StoneAge.System.Utils.Tests.Json
{
    [TestFixture]
    public class JsonExtensionsTests
    {
        [Test]
        public void TryDeserialize_WhenPopulatedParsableModel_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var model = new TestObject {Foo = 1, MagicProperty = "Walking on water, cuz I trained some turtles" }.Serialize();
            //---------------Execute Test ----------------------
            var result = model.TryDeserialize<TestObject>();
            //---------------Test Result -----------------------
            result.IsValid.Should().BeTrue();
            result.Model.Should().NotBeNull();
        }

        [Test]
        public void TryDeserialize_WhenEmptyParsableModel_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var model = new TestObject().Serialize();
            //---------------Execute Test ----------------------
            var result = model.TryDeserialize<TestObject>();
            //---------------Test Result -----------------------
            result.IsValid.Should().BeTrue();
            result.Model.Should().NotBeNull();
        }

        [Test]
        public void TryDeserialize_WhenNotParsableModel_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var model = "{ \"name\" : Bob \"age\": 36}";
            //---------------Execute Test ----------------------
            var result = model.TryDeserialize<TestObject>();
            //---------------Test Result -----------------------
            result.IsValid.Should().BeFalse();
            result.Model.Should().BeNull();
        }

        [Test]
        public void Serialize_WhenObjectContainTitleCaseProperties_ShouldReturnCamelcaseProperties()
        {
            //---------------Set up test pack-------------------
            var expected = "{\"Foo\":\"bar\",\"MagicProperty\":\"foobar\"}";
            var input = new
            {
                Foo = "bar",
                MagicProperty = "foobar"
            };
            //---------------Execute Test ----------------------
            var result = input.Serialize();
            //---------------Test Result -----------------------
            result.Should().Be(expected);
        }

        [Test]
        public void Serialize_WhenObjectContainTitleCaseProperties_ShouldReturnLowerCaseProperties()
        {
            //---------------Set up test pack-------------------
            var expected = "{\"foo\":\"bar\",\"magicproperty\":\"foobar\"}";
            var input = new
            {
                Foo = "bar",
                MagicProperty = "foobar"
            };
            //---------------Execute Test ----------------------
            var result = input.Serialize_With_LowerCase_Settings();
            //---------------Test Result -----------------------
            result.Should().Be(expected);
        }

        [Test]
        public void Deserialize_WhenObjectContainTitleCaseProperties_ShouldReturnCamelcaseProperties()
        {
            //---------------Set up test pack-------------------
            var input = @"{""foo"" : 1, ""magicProperty"": ""bar""}";
            //---------------Execute Test ----------------------
            var result = input.Deserialize<TestObject>();
            //---------------Test Result -----------------------
            result.Foo.Should().Be(1);
            result.MagicProperty.Should().Be("bar");
        }

    }
}
