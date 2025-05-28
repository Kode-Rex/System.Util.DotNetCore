using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Async;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoneAge.System.Utils.Tests.Async
{
    [TestFixture]
    public class ParallelForEachAsyncTests
    {
        [Test]
        public async Task Should_Iterate_Collection()
        {
            // arrange
            var result = new ConcurrentBag<int>();
            var input = Enumerable.Range(1, 20);
            // act
            await input.ForEachAsync(async x =>
            {
                result.Add(x + 1);
                await Task.Delay(10);
            }, 2);
            // assert
            result.Count().Should().Be(20);
        }

        [Test]
        public async Task When_Empty_List_Should_Do_Nothing()
        {
            // arrange
            var result = new List<int>();
            var input = new List<int>();
            // act
            await input.ForEachAsync(async x =>
            {
                result.Add(x + 1);
                await Task.Delay(10);
            }, 2);
            // assert
            result.Count().Should().Be(0);
        }

        [Test]
        [Ignore("Not possible")]
        public async Task When_Exception_Should_Throw_Exception()
        {
            // arrange
            var result = new List<int>();
            var input = Enumerable.Range(1, 20);
            // act
            var actual = Assert.ThrowsAsync<Exception>(async () =>{
                await input.ForEachAsync(async x=>
                {
                    throw new Exception("error");
                }, 2);
            });

            // assert
            actual.Message.Should().Be("error");
        }
    }
}
