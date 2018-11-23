using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Copy;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoneAge.System.Utils.Tests.Copy
{
    [TestFixture]
    public class ObjectPropertyCopierTests
    {
        [Test]
        public void CopyPropertiesTo_WhenSameObjects_ShouldCopyAllProperties()
        {
            //---------------Arrange------------------
            var instance1 = new TestObject
            {
                Id = 1001,
                AccountId = 1,
                AccountName = "account name",
                AmountCharged = 1.01M,
                BillTime = DateTime.MinValue,
                BilledSeconds = 11,
                CallId = "abc-xyz",
                PortaId = 2,
                Cld = "111",
                Cli = "222",
                Network = null,
                RateHistory = "xx@yy",
                RecordType = "record type",
                ServiceType = "service type",
                Created = DateTime.Today,
                Modifed = DateTime.Today
            };
            var instance2 = new TestObject();

            //---------------Act----------------------
            instance1.CopyPropertiesTo(instance2);
            //---------------Assert-------------------
            instance2.Should().BeEquivalentTo(instance1);
        }

        [Test]
        public void CopyPropertiesTo_WhenSomeFieldsIgnored_ShouldCopyNotIngoredProperties()
        {
            //---------------Arrange------------------
            var instance1 = new TestObject
            {
                Id = 1001,
                AccountId = 1,
                AccountName = "account name",
                AmountCharged = 1.01M,
                BillTime = DateTime.MinValue,
                BilledSeconds = 11,
                CallId = "abc-xyz",
                PortaId = 2,
                Cld = "111",
                Cli = "222",
                Network = null,
                RateHistory = "xx@yy",
                RecordType = "record type",
                ServiceType = "service type",
                Created = DateTime.Today,
                Modifed = DateTime.Today
            };
            var instance2 = new TestObject();

            //---------------Act----------------------
            instance1.CopyPropertiesTo(instance2, new[] { "Created" });
            //---------------Assert-------------------
            var expected = new TestObject
            {
                Id = 1001,
                AccountId = 1,
                AccountName = "account name",
                AmountCharged = 1.01M,
                BillTime = DateTime.MinValue,
                BilledSeconds = 11,
                CallId = "abc-xyz",
                PortaId = 2,
                Cld = "111",
                Cli = "222",
                Network = null,
                RateHistory = "xx@yy",
                RecordType = "record type",
                ServiceType = "service type",
                Created = DateTime.MinValue,
                Modifed = DateTime.Today
            };
            instance2.Should().BeEquivalentTo(expected);
        }
    }
}
