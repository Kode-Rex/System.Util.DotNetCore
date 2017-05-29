using NUnit.Framework;
using TddBuddy.System.Utils.JsonUtils;

namespace TddBuddy.System.Utils.Tests.JsonUtils
{
    [TestFixture]
    public class JsonExtensionsTests
    {
        [Test]
        public void TryParseModel_WhenPopulatedParsableModel_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var model = new TestParsingObject {Foo = 1, MagicProperty = "Walking on water, cuz I trained some turtles" }.Serialize();
            //---------------Execute Test ----------------------
            var result = model.TryParseModel<TestParsingObject>();
            //---------------Test Result -----------------------
            Assert.IsTrue(result.IsValid);
            Assert.IsNotNull(result.ParsedModel);
        }

        [Test]
        public void TryParseModel_WhenEmptyParsableModel_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var model = new TestParsingObject().Serialize();
            //---------------Execute Test ----------------------
            var result = model.TryParseModel<TestParsingObject>();
            //---------------Test Result -----------------------
            Assert.IsTrue(result.IsValid);
            Assert.IsNotNull(result.ParsedModel);
        }

        [Test]
        public void TryParseModel_WhenNotParsableModel_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var model = "{ \"name\" : Bob \"age\": 36}";
            //---------------Execute Test ----------------------
            var result = model.TryParseModel<TestParsingObject>();
            //---------------Test Result -----------------------
            Assert.IsFalse(result.IsValid);
            Assert.IsNull(result.ParsedModel);
        }

        [Test]
        public void Serialize_WhenObjectContainTitleCaseProperties_ShouldReturnCamelcaseProperties()
        {
            //---------------Set up test pack-------------------
            var expected = "{\"foo\":\"bar\",\"magicProperty\":\"foobar\"}";
            var input = new
            {
                Foo = "bar",
                MagicProperty = "foobar"
            };
            //---------------Execute Test ----------------------
            var result = input.Serialize();
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseModel_WhenObjectContainTitleCaseProperties_ShouldReturCamelcaseProperites()
        {
            //---------------Set up test pack-------------------
            var input = @"{""foo"" : 1, ""magicProperty"": ""bar""}";
            //---------------Execute Test ----------------------
            var result = input.ParseModel<TestParsingObject>();
            //---------------Test Result -----------------------
            Assert.AreEqual(1, result.Foo);
            Assert.AreEqual("bar", result.MagicProperty);
        }

    }
}
