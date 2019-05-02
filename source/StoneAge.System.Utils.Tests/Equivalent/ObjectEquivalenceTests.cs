using System;
using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Copy;
using StoneAge.System.Utils.Equivalent;
using StoneAge.System.Utils.Tests.Copy;

namespace StoneAge.System.Utils.Tests.Equivalent
{
    [TestFixture]
    public class ObjectEquivalenceTests
    {
        [Test]
        public void WhenNotEquivalentObjects_ShouldReturnFalse()
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
            var actual = instance1.EquivalentTo(instance2);
            //---------------Assert-------------------
            actual.Should().BeFalse();
        }

        [Test]
        public void WhenSameObjects_ShouldReturnTrue()
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

            //---------------Act----------------------
            var actual = instance1.EquivalentTo(instance1);
            //---------------Assert-------------------
            actual.Should().BeTrue();
        }

        [Test]
        public void WhenEquivalentObjects_ShouldReturnTrue()
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
                ServiceType = "service type"
            };

            var instance2 = new TestObject
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
                ServiceType = "service type"
            };

            //---------------Act----------------------
            var actual = instance1.EquivalentTo(instance2);
            //---------------Assert-------------------
            actual.Should().BeTrue();
        }

        [Test]
        public void WhenSomeFieldsWithDifferencesIgnored_ShouldReturnTrue()
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
            var instance2 = new TestObject
            {
                Id = 1002,
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

            //---------------Act----------------------
            var actual = instance1.EquivalentTo(instance2, new[] { "Id", "Created" });
            //---------------Assert-------------------
            actual.Should().BeTrue();
        }
    }
}
