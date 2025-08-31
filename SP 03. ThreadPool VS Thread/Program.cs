// ThreadPool VS Thread

using System.Diagnostics;

int operationCount = 100;
var watch = new Stopwatch();



watch.Start();
UseThread(operationCount);
watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");

watch.Reset();

Console.WriteLine();

watch.Start();
UseThreadPool(operationCount);
watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");

watch.Reset();
void UseThread(int operationCount)
{
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("Threads...");
        List<int> threadIds = new();
        for (int i = 0; i < operationCount; i++)
        {
            var thread = new Thread(() =>
            {
                Thread.Sleep(1);
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");

                if (!threadIds.Contains(Thread.CurrentThread.ManagedThreadId))
                    {
                        threadIds.Add(Thread.CurrentThread.ManagedThreadId);
                    }
                

                count.Signal();
            });
            thread.Start();
        }
        count.Wait();
        Console.WriteLine(threadIds.Count);
    }
}

void UseThreadPool(int operationCount)
{
    List<int> threadIds = new();
    using (var count = new CountdownEvent(operationCount))
    {
        Console.WriteLine("ThreadPool...");
        for (int i = 0; i < operationCount; i++)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Thread.Sleep(1);
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");

                if (!threadIds.Contains(Thread.CurrentThread.ManagedThreadId))
                    {
                        threadIds.Add(Thread.CurrentThread.ManagedThreadId);
                    }
               
                count.Signal();
            });
        }
        count.Wait();
        Console.WriteLine(threadIds.Count);
    }
}
