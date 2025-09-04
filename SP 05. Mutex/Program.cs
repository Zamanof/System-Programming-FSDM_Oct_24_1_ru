// Mutex -> Mutual exclusion

#region Mutex - internal thread
//Mutex mutex = new();

//int numb = 1;
//for (int i = 0; i < 5; i++)
//{
//    Thread thread = new(Count);
//	thread.Name = $"mr. Thread {i+1}";
//	thread.Start();
//}


//void Count()
//{
//	mutex.WaitOne();
//	for (int i = 0; i < 10; i++)
//	{
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {numb++}");
//	}
//	mutex.ReleaseMutex();
//}
#endregion

#region Mutex - external (global) thread
//string mutexName = "Jdun";
//using (var mutex = new Mutex(true, mutexName))
//{
//    if (!mutex.WaitOne(30000))
//    {
//        Console.WriteLine("Other instance running...");
//        Thread.Sleep(1000);
//        return;
//    }
//    else
//    {
//        Console.WriteLine("My Code running");
//        Console.ReadKey();
//        mutex.ReleaseMutex();
//    }
//}
#endregion
