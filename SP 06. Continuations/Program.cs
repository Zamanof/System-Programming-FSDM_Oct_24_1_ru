// Continuations
#region ContinueWith OnlyOnRanToCompletetaion
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
//var secondTask = new Task<int>(() => TaskMethod("Second Task", 4));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task Start");
//    Console.WriteLine($"Task result: {t.Result}");
//    Console.WriteLine($@"Id:             {Thread.CurrentThread.ManagedThreadId}
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);

//secondTask.ContinueWith((t) =>
//{
//    OtherMethod();
//}, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted);

//firstTask.Start();
//secondTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}

//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("End");
#endregion

#region ContinueWith OnlyOnFaulted
//try
//{
//    var firstTask = new Task<int>(() => TaskMethod("First Task", 3));

//    firstTask.ContinueWith((t) =>
//    {
//        Console.WriteLine("ContinueWith task Start");
//        Console.WriteLine($@"Id:             {Thread.CurrentThread.ManagedThreadId}
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}");
//    }, TaskContinuationOptions.OnlyOnFaulted);



//    firstTask.Start();



//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
//Console.ReadKey();
#endregion

#region ContinueWith with Thread
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task Start");
//    Console.WriteLine($@"Id:             {Thread.CurrentThread.ManagedThreadId}
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}");
//    Console.WriteLine("ContinueWith task End");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning);
//firstTask.Start();

//Console.ReadLine();
#endregion

#region ContinueWith ExecuteSyncronously
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine("ContinueWith task Start");
//    Console.WriteLine($@"Id:             {Thread.CurrentThread.ManagedThreadId}
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}");
//    Console.WriteLine("ContinueWith task End");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
//firstTask.Start();

//Console.ReadLine();
#endregion

#region Task.Status
// Created
// WaitingForActivation
// WaitingToRun
// Running
// WaitingForChildrenToComplete
// RanToCompletion
// Canceled
// Faulted
var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
try
{
    Console.WriteLine(firstTask.Status);
    firstTask.Start();
    while (true)
    {
        Console.WriteLine(firstTask.Status);
        Thread.Sleep(100);
        if (firstTask.IsCompleted) break;
    }
    firstTask.Wait();
    Console.WriteLine(firstTask.Status);
}
catch (Exception)
{
    Console.WriteLine(firstTask.Status);
}


#endregion


int TaskMethod(string message, int second)
{
    Console.WriteLine($"Task - {message} start.");
    Console.WriteLine($@"
Id:             {Thread.CurrentThread.ManagedThreadId}
IsBackground:   {Thread.CurrentThread.IsBackground}
IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
");
    Thread.Sleep(TimeSpan.FromSeconds(second));
    throw new Exception("Any exception");

    Console.WriteLine($"Task - {message} end.");
    return second * 10;
}

void OtherMethod()
{
    Console.WriteLine("Other method start.");
    Console.WriteLine($@"
Id:             {Thread.CurrentThread.ManagedThreadId}
IsBackground:   {Thread.CurrentThread.IsBackground}
IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
");


    Console.WriteLine("Other method end.");

}