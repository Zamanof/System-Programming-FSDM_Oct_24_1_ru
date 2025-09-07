// TPL - Task Parallel Library

// Thread -> ThreadPool -> TPL


Task task1 = new Task(() =>
{
    TaskMethod("Task1");
});
Task task2 = new Task(() =>
{
    TaskMethod("Task2");
});

Task task3 = Task.Run(() =>
{
    TaskMethod("Task3");
});

Task task4 = Task.Factory.StartNew(() =>
{
    TaskMethod("Task4");
});

Task task5 = new Task(() =>
{
    TaskMethod("Task5");
},TaskCreationOptions.LongRunning);


task1.Start();
task2.Start();
task5.Start();


void TaskMethod(string message)
{
    Console.WriteLine($@"
Name:           {message}
Id:             {Thread.CurrentThread.ManagedThreadId}
IsBackground:   {Thread.CurrentThread.IsBackground}
IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
");
}

