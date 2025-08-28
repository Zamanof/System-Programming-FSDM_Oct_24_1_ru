// Threads
//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//Console.WriteLine(Thread.CurrentThread.IsBackground);

Thread thread1 = new Thread(() =>
{
    int a = 0;
    //for (int i = 0; i < 1000; i++)
    //{
    //    Console.WriteLine($"\tMy Own Thread - Id:({Thread.CurrentThread.ManagedThreadId}) - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    //}
    ConsoleKey consoleKey = new();
    while (true)
    {
        Console.WriteLine(a);
        a++;
        consoleKey = Console.ReadKey().Key;
        if (consoleKey == ConsoleKey.Enter)
        {
            Thread.CurrentThread.Interrupt();
        }
        Thread.Sleep(100);
        Console.Clear();
    }
});

//Thread thread2 = new Thread(Some);
//thread1.IsBackground = true;
//thread1.Priority = ThreadPriority.Highest;
//thread2.Priority = ThreadPriority.Lowest;

thread1.Start();
//thread2.Start();

//for (int i = 0; i < 100; i++)
//{
//    Console.WriteLine($"Main Thread - Id:({Thread.CurrentThread.ManagedThreadId}) - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
//}

/*thread1.Join();*/ // Zastavlyayet vizivayushiy thread podojdat vizivaemiy thread
//ConsoleKey consoleKey;
//while (true)
//{
//    consoleKey = Console.ReadKey().Key;
//    if (consoleKey == ConsoleKey.Enter)
//    {
//        thread1.Interrupt();
//        break;
//    }
//}
//thread1.Interrupt();

void Some()
{

    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"\t\tSome Thread - Id:({Thread.CurrentThread.ManagedThreadId}) - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
}

