using FluentAssertions;
using NUnit.Framework;
using StoneAge.System.Utils.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneAge.System.Utils.Tests.Async
{
    [TestFixture]
    public class ParallelForEachAsyncTests
    {
        [Test]
        public async Task test()
        {
            // arrange
            var result = new List<int>();
            var input = Enumerable.Range(1, 20);
            // act
            await input.ForEachAsync(new Func<int, Task>(async x =>
            {
                result.Add(x + 1);
            }), 2);
            // assert
            result.Count().Should().Be(20);
        }
    }
}
