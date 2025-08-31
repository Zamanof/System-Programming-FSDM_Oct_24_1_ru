// ThreadPool

/*
CLR ThreadPool thread-i ispolzuyut:
1. class ThreadPool
2. WinForm Timer
3. Asinxronniye metodi (.BeginInvoke(), .EndInvoke()) - ustarelo
4. TPL
...
 
*/

//ThreadPool.GetAvailableThreads(out int workerCount, out int compCount);
//Console.WriteLine(workerCount);
//Console.WriteLine(compCount);
Console.WriteLine("Main method start ...");

ThreadPool.QueueUserWorkItem(OtherOperations, "Salam");
ThreadPool.QueueUserWorkItem(o =>
{
    SomeOperations();
});

Console.ReadKey();

Console.WriteLine("Main operations method end ...");





void SomeOperations()
{
    Console.WriteLine("\t\tSome operations method start ...");
    Console.WriteLine($"\t\tSome operations thread id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\t\tSome operations thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\t\tSome operations thread isThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\t\tSome operations method end ...");
}

void OtherOperations(object state)
{
    Console.WriteLine("\tOther operations method start ...");
    Console.WriteLine($"\tState: {state}");
    Console.WriteLine($"\tOther operations thread id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\tOther operations thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\tOther operations thread isThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\tOther operations method end ...");
}



