// Thread -> ThreadPool -> Task -> syntax sugar + love = async await

Console.WriteLine($"Main method start in thread {Thread.CurrentThread.ManagedThreadId}"); // main thread 
//SomeMethod();
SomeMethodAsync();
Console.ReadLine();
Console.WriteLine($"Main method end in thread {Thread.CurrentThread.ManagedThreadId}"); // main thread 
void SomeMethod()
{
    Console.WriteLine($"Some method start in thread {Thread.CurrentThread.ManagedThreadId}"); // main thread 
    var result = Task.Run<int>(() =>
    {
        Console.WriteLine($"Some method task start in {Thread.CurrentThread.ManagedThreadId}"); // any thread from ThreadPool
        Thread.Sleep(1000);
        Console.WriteLine($"Some method task end in {Thread.CurrentThread.ManagedThreadId}");   // same thread where started
        return 78;
    });
    Console.WriteLine(@$"Some method end in thread {Thread.CurrentThread.ManagedThreadId} 
result = {result.Result}"); // main thread
}

async void SomeMethodAsync()
{
    Console.WriteLine($"Some method start in thread {Thread.CurrentThread.ManagedThreadId}"); // main thread 
    var result = await Task.Run<int>(() =>
     {
         Console.WriteLine($"Some method task start in {Thread.CurrentThread.ManagedThreadId}"); // any thread from ThreadPool
         Thread.Sleep(1000);
         Console.WriteLine($"Some method task end in {Thread.CurrentThread.ManagedThreadId}");   // same thread where started
         return 78;
     });
    Console.WriteLine($@"Some method end in thread {Thread.CurrentThread.ManagedThreadId}
result={result}"); // main thread
}