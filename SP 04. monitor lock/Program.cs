#region Albahari tricks
// First Trick
//for (int i = 0; i < 10; i++)
//{
//    new Thread(() =>
//    {
//        Console.WriteLine(i);
//    }).Start();
//}


//for (int i = 0; i < 10; i++)
//{
//    int temp = i;
//    new Thread(() =>
//    {
//        Console.WriteLine(temp);
//    }).Start();
//}

// Second Trick
//string name = "Nadir";
//Thread thread1 = new(() =>
//{
//    Console.WriteLine(name);
//});

//name = "Zaman";

//Thread thread2 = new(() =>
//{
//    Console.WriteLine(name);
//});

//thread1.Start();
//thread2.Start();
#endregion

// Critical section - obrosheniye thread-ov na odnu i tu ju pamyat(resurs)

#region Critical section problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Counter.count++;
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

////Console.WriteLine(Counter.count);

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.count);
#endregion

#region Interlocked
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Interlocked.Increment(ref Counter.count);
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

////Console.WriteLine(Counter.count);

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.count);
#endregion

#region Interlocked problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Interlocked.Increment(ref Counter.count);

//            if (Counter.count % 2 == 0)
//            {
//                Interlocked.Increment(ref Counter.even);
//            }
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

////Console.WriteLine(Counter.count);

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.count);
//Console.WriteLine(Counter.even);
#endregion

#region Monitor
Thread[] threads = new Thread[5];
object obj = new();
for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000000; j++)
        {
            Monitor.Enter(obj);
            try
            {
                Counter.count++;

                if (Counter.count % 2 == 0)
                {
                    Counter.even++;
                }
            }
            finally
            {

                Monitor.Exit(obj);
            }

        }
    });
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}

//Console.WriteLine(Counter.count);

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}
Console.WriteLine(Counter.count);
Console.WriteLine(Counter.even);
#endregion

#region lock
//Thread[] threads = new Thread[5];
//object obj = new();
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new Thread(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            // lock - monitor syntax sugar 
//            lock (obj)
//            {
//                Counter.count++;

//                if (Counter.count % 2 == 0)
//                {
//                    Counter.even++;
//                }
//            }
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

////Console.WriteLine(Counter.count);

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}
//Console.WriteLine(Counter.count);
//Console.WriteLine(Counter.even);
#endregion


