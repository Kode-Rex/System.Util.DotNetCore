using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoneAge.System.Utils.Async
{
    public static class ParallelForEachAsync
    {
        public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action, int maxParallelCount = 4)
        {
            if (source.Count() == 0)
            {
                return;
            }

            using (SemaphoreSlim completeSemphoreSlim = new SemaphoreSlim(1))
            using (SemaphoreSlim taskCountLimitsemaphoreSlim = new SemaphoreSlim(maxParallelCount))
            {
                await completeSemphoreSlim.WaitAsync();
                int runningtaskCount = source.Count();

                foreach (var item in source)
                {
                    await taskCountLimitsemaphoreSlim.WaitAsync();

                    Task.Run(async () =>
                    {
                        try
                        {
                            await action(item).ContinueWith(task =>
                            {
                                Interlocked.Decrement(ref runningtaskCount);
                                if (runningtaskCount == 0)
                                {
                                    completeSemphoreSlim.Release();
                                }
                            });
                        }
                        finally
                        {
                            taskCountLimitsemaphoreSlim.Release();
                        }
                    }).GetHashCode();
                }

                await completeSemphoreSlim.WaitAsync();
            }
        }


        //public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action, int maxParallelCount = 4)
        //{
        //    if (source.Count() == 0)
        //    {
        //        return;
        //    }

        //    using (SemaphoreSlim completeSemphoreSlim = new SemaphoreSlim(1))
        //    using (SemaphoreSlim taskCountLimitsemaphoreSlim = new SemaphoreSlim(maxParallelCount))
        //    {
        //        await completeSemphoreSlim.WaitAsync();
        //        int runningtaskCount = source.Count();

        //        foreach (var item in source)
        //        {
        //            await taskCountLimitsemaphoreSlim.WaitAsync();

        //            await Task.Run(async () =>
        //            {
        //                try
        //                {
        //                    await action(item).ContinueWith(task =>
        //                    {
        //                        Interlocked.Decrement(ref runningtaskCount);
        //                        if (runningtaskCount == 0)
        //                        {
        //                            completeSemphoreSlim.Release();
        //                        }

        //                        if (task.Exception != null)
        //                        {
        //                            throw task.Exception.InnerException;
        //                        }

        //                    });
        //                }
        //                catch (Exception e)
        //                {
        //                    throw;
        //                }
        //                finally
        //                {
        //                    taskCountLimitsemaphoreSlim.Release();
        //                }
        //            });
        //        }

        //        await completeSemphoreSlim.WaitAsync();
        //    }
        //}
    }
}
