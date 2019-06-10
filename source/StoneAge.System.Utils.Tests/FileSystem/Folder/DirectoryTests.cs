using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.FileSystem.Folder;
using Directory = StoneAge.System.Utils.FileSystem.Folder.Directory;

namespace StoneAge.System.Utils.Tests.FileSystem.Folder
{
    [TestFixture]
    public class DirectoryTests
    {
        [TestFixture]
        class Exist
        {
            [Test]
            public void WhenDirectoryExist_ShouldReturnTrue()
            {
                //---------------Arrange-------------------
                var sut = new Directory {Location = Path.GetTempPath()};
                //---------------Act----------------------
                var actual = sut.Exists();
                //---------------Assert-----------------------
                actual.Should().BeTrue();
            }

            [Test]
            public void WhenDirectoryDoesNotExist_ShouldReturnFalse()
            {
                //---------------Arrange-------------------
                var sut = new Directory { Location = "Z:\\Foo\\Bar" };
                //---------------Act----------------------
                var actual = sut.Exists();
                //---------------Assert-----------------------
                actual.Should().BeFalse();
            }
        }

        [TestFixture]
        class List_Files
        {
            [Test]
            public void WhenDirectoryExist_ShouldReturnTrue()
            {
                //---------------Arrange-------------------
                var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                global::System.IO.Directory.CreateDirectory(path);
                var sut = new Directory { Location = path };
                //---------------Act----------------------
                var actual = sut.List_Files();
                //---------------Assert-----------------------
                actual.Should().BeEquivalentTo(new List<FileInformation>());
            }
        }
    }
}
