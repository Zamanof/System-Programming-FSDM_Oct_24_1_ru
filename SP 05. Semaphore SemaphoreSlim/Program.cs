#region Semaphore internal
//Semaphore semaphore = new(3, 3);
//for (int i = 0; i < 30; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}


//void Some(object state)
//{
//    Random random = new Random();
//    var s = state as Semaphore;
//    bool st = false;
//    while (!st)
//    {
//        if (s.WaitOne(500))
//        {
//            try
//            {
//                Thread.Sleep(1);
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} take key");

//                Thread.Sleep(random.Next(1000, 3000));
//            }
//            finally
//            {
//                Thread.Sleep(1);
//                st = true;
//                Console.WriteLine($"    mr. {Thread.CurrentThread.ManagedThreadId} return key");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(1);
//            Console.WriteLine($"        mr. {Thread.CurrentThread.ManagedThreadId}, sorry no keys yet");
//        }
//    }
//}
#endregion


#region Semaphore external
//Semaphore semaphore = new(3, 3, "Put in");
//for (int i = 0; i < 30; i++)
//{
//    ThreadPool.QueueUserWorkItem(Some, semaphore);
//}


//void Some(object state)
//{
//    DateTime time = DateTime.Now;
//    Random random = new Random();
//    var s = state as Semaphore;
//    bool st = false;
//    while (!st)
//    {
//        if (s.WaitOne(500))
//        {
//            try
//            {
//                Thread.Sleep(1);
//                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} take key; {time.ToLongTimeString()}");

//                Thread.Sleep(random.Next(1000, 3000));
//            }
//            finally
//            {
//                Thread.Sleep(1);
//                st = true;
//                Console.WriteLine($"    mr. {Thread.CurrentThread.ManagedThreadId} return key; {time.ToLongTimeString()}");
//                s.Release();
//            }
//        }
//        else
//        {
//            Thread.Sleep(1);
//            Console.WriteLine($"        mr. {Thread.CurrentThread.ManagedThreadId}, sorry no keys yet");
//        }
//    }

//}
#endregion

#region Semaphore internal
SemaphoreSlim semaphore = new(3, 3);
for (int i = 0; i < 30; i++)
{
    ThreadPool.QueueUserWorkItem(Some, semaphore);
}


void Some(object state)
{
    Random random = new Random();
    var s = state as SemaphoreSlim;
    bool st = false;
    while (!st)
    {
        if (s.Wait(500))
        {
            try
            {
                Thread.Sleep(1);
                Console.WriteLine($"mr. {Thread.CurrentThread.ManagedThreadId} take key");

                Thread.Sleep(random.Next(1000, 3000));
            }
            finally
            {
                Thread.Sleep(1);
                st = true;
                Console.WriteLine($"    mr. {Thread.CurrentThread.ManagedThreadId} return key");
                s.Release();
            }
        }
        else
        {
            Thread.Sleep(1);
            Console.WriteLine($"        mr. {Thread.CurrentThread.ManagedThreadId}, sorry no keys yet");
        }
    }
}
#endregion


Console.ReadKey();