using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.FileSystem.File;

namespace StoneAge.System.Utils.Tests.FileSystem.File
{
    [TestFixture]
    public class DocumentTests
    {
        // todo : create file factory to abstract creation
        [TestFixture]
        class Write
        {
            [Test]
            public async Task WhenDoesNotAlreadyExist_ShouldSaveFile()
            {
                //---------------Arrange-------------------
                var file = Create_Document("a line of text", Path.GetTempPath());
                //---------------Act----------------------
                await file.Write();
                //---------------Assert-----------------------
                var fileExist = global::System.IO.File.Exists(file.Full_Path());
                fileExist.Should().BeTrue();
            }

            [Test]
            public async Task WhenAlreadyExist_ShouldSaveFileOver()
            {
                //---------------Arrange-------------------
                var file = Create_Document("some stuff", Path.GetTempPath());

                global::System.IO.File.WriteAllText(file.Full_Path(), "a line of text");

                //---------------Act----------------------
                await file.Write();
                //---------------Assert-----------------------
                var fileContents = global::System.IO.File.ReadAllText(file.Full_Path());
                fileContents.Should().Be("some stuff");
            }
        }

        [TestFixture]
        class Exist
        {
            [Test]
            public void WhenFileExist_ShouldReturnTrue()
            {
                //---------------Arrange-------------------
                var file = Create_Document("a line of text", Path.GetTempPath());
                //---------------Act----------------------
                var actual = file.Exists();
                //---------------Assert-----------------------
                actual.Should().BeTrue();

            }

            [Test]
            public void WhenFileDoesNotExist_ShouldReturnFalse()
            {
                //---------------Arrange-------------------
                var file = new Document
                {
                    Location = "z:\\foo\\bar",
                    Name = "file.txt"
                };
                //---------------Act----------------------
                var actual = file.Exists();
                //---------------Assert-----------------------
                actual.Should().BeFalse();

            }
        }

        [TestFixture]
        class Delete
        {
            [Test]
            public void WhenFileExist_ShouldDeleteIt()
            {
                //---------------Arrange-------------------
                var file = Create_Document("a line of text", Path.GetTempPath());
                //---------------Act----------------------
                file.Delete();
                //---------------Assert-----------------------
                var fileExist = global::System.IO.File.Exists(file.Full_Path());
                fileExist.Should().BeFalse();

            }

            [Test]
            public void WhenFileDoesNotExist_ShouldNotThrowException()
            {
                //---------------Arrange-------------------
                var file = new Document
                {
                    Location = "z:\\foo\\bar",
                    Name = "file.txt"
                };
                //---------------Act----------------------
                //---------------Assert-----------------------
                Assert.DoesNotThrow(()=>file.Delete());
            }
        }

        private static IDocument Create_Document(string fileContents, string directoryLocation)
        {
            var file = new Document
            {
                Location = directoryLocation,
                Name = Guid.NewGuid()+".test",
                Bytes = Encoding.UTF8.GetBytes(fileContents)
            };
            return file;
        }

    }
}
