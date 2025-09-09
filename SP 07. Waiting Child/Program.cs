// See https://aka.ms/new-console-template for more information
var grandFatherTask = new Task<int>(() => {

    var fatherTask = Task.Factory.StartNew(() =>
    {
        var grandSonTask = Task.Factory.StartNew(() =>
        {
            TaskMethod("Grandson task", 8);
        }, TaskCreationOptions.AttachedToParent);
        TaskMethod("Father task", 5);
    }, TaskCreationOptions.AttachedToParent);

    return TaskMethod("GrandFather task", 3);
});
grandFatherTask.Start();
Console.WriteLine(grandFatherTask.Result);
Console.WriteLine("End");
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
