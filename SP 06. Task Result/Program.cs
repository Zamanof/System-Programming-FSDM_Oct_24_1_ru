// Task Result

Task<int> task = Task.Run(() => TaskReturnMethod("Task1", 3));

var result = task.Result;
Console.WriteLine(result);

int TaskReturnMethod(string message, int second)
{
    Console.WriteLine($@"
Name:           {message}
Id:             {Thread.CurrentThread.ManagedThreadId}
IsBackground:   {Thread.CurrentThread.IsBackground}
IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
");
    Thread.Sleep(TimeSpan.FromSeconds(second));
    return second * 10;
}