using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Hash;

namespace StoneAge.System.Utils.Tests.Hash
{
    [TestFixture]
    public class ObjectPropertyHashTests
    {
        [Test]
        public void Calculate_Hash_WhenAllProperties_ShouldReturnObjectHash()
        {
            //---------------Arrange------------------
            var sut = new XTeamUser
            {
                PortaId = 999,
                Login = "user1",
                Password = "666",
                Disabled = false,
                Auth0Connection = "XTeam-Username"
            };
            //---------------Act----------------------
            var actual = sut.Calculate_Hash();
            //---------------Assert-------------------
            var expected = "48da4949dcc46921a5b497d79ecc639763e3d9a972d9baaf19b057d2fbbce87f";
            actual.Should().BeEquivalentTo(expected);
        }
    }

    internal class XTeamUser
    {
        public int PortaId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Disabled { get; set; }
        public string Auth0Connection { get; set; }
    }
}
