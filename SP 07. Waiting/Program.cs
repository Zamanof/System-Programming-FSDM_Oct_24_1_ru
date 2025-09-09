// Waiting
#region Single Wait
//var firstTask = new Task<int>(()=>TaskMethod("First", 10));
//firstTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}
////Console.WriteLine(firstTask.Result);
//firstTask.Wait();
//Console.WriteLine("End of code");
#endregion

#region Wait all
//var firstTask = new Task<int>(() => TaskMethod("First", 10));
//var secondTask = new Task<int>(() => TaskMethod("Second", 15));
//firstTask.Start();
//secondTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}
////Console.WriteLine(firstTask.Result);
//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("End of code");
#endregion

#region Wait any
var firstTask = new Task<int>(() => TaskMethod("First", 10));
var secondTask = new Task<int>(() => TaskMethod("Second", 5));
firstTask.Start();
secondTask.Start();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main thread - {i}");
    Thread.Sleep(10);
}
//Console.WriteLine(firstTask.Result);
Task.WaitAny(firstTask, secondTask);
Console.WriteLine("End of code");
#endregion


int TaskMethod(string message, int secconds)
{
    Console.WriteLine(@$"Task - {message} running
Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackGround = {Thread.CurrentThread.IsBackground}
");
    Thread.Sleep(TimeSpan.FromSeconds(secconds));
    Console.WriteLine($"Task - {message} end");
    return secconds * 10;
}