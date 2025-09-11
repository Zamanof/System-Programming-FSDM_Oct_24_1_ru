// Parallel, PLINQ

using System.Collections.Concurrent;
using System.Diagnostics;

List<Student> students = new List<Student>();
for (int i = 0; i < 10000000; i++)
{
    students.Add(new Student()
    {
        Id = i + 1,
        FirstName = Faker.NameFaker.FirstName(),
        LastName = Faker.NameFaker.LastName(),
        Age = Faker.NumberFaker.Number(18, 60),
        Mark = Faker.NumberFaker.Number(10, 120) / 10.0,
        Email = Faker.InternetFaker.Email()
    });
}

#region Task wait, when, continue
//var t1 = Task.Run(() =>
//{
//    for (int i = 0; i < students.Count / 2; i++)
//    {
//        students[i].Group = "FSDM_Oct_24_1_ru";
//        Thread.Sleep(10);
//    }
//});
//var t2 = Task.Run(() =>
//{
//    for (int i = students.Count / 2; i < students.Count ; i++)
//    {
//        students[i].Group = "FSDM_Oct_24_1_az";
//        Thread.Sleep(10);
//    }
//});

////Task.WaitAll(t1, t2);

//Task.WhenAll(
//    t1, 
//    t2, 
//    WriteDataLog(), 
//    SendEmailNotification(), 
//    SendSMSNotification())
//    .ContinueWith(t =>
//    {
//        Console.WriteLine("Continue with Task");
//    });

//Console.WriteLine("End");
//Console.ReadKey();
//Task WriteDataLog() => Task.Delay(500);
//Task SendEmailNotification() => Task.Delay(700);
//Task SendSMSNotification() => Task.Delay(300);
#endregion

#region Parallel
//Parallel.For(0, students.Count, new ParallelOptions
//{ MaxDegreeOfParallelism = 6 }, i=>
//{
//    students[i].Group = "FSDM_Oct_24_1_ru";
//    Console.WriteLine($@"
//Thread Id:      {Thread.CurrentThread.ManagedThreadId}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
//IsBackGround:   {Thread.CurrentThread.IsBackground}
//");
//}
//);
//Stopwatch stopwatch = new();
//stopwatch.Start();

//for (int i = 0; i < students.Count; i++)
//{
//    students[i].Group = "FSDM_Oct_24_1_ru";
//    Thread.Sleep(1);
//}
//var syncFor = stopwatch.ElapsedTicks;
//stopwatch.Restart();
//stopwatch.Start();
//Parallel.For(0, students.Count, i =>
//{
//    students[i].Group = "FSDM_Oct_24_1_ru";
//    Thread.Sleep(1);
//}
//);
//var parallelFor = stopwatch.ElapsedTicks;
//stopwatch.Stop();
//Console.WriteLine($"Snychrony for: {syncFor}");
//Console.WriteLine($"Parallel for: {parallelFor}");
//Console.ReadLine();
#endregion

#region PLINQ
//Stopwatch stopwatch = new();
//stopwatch.Start();
//var parallelCount = 0;

//var obj = new object();
//Parallel.ForEach(students, s =>
//{
//    if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//    {
//        //lock (obj)
//        //{
//        //    parallelCount++;
//        //}
//        Interlocked.Increment(ref parallelCount);
//    }
//}

//);
//var parallelFor = stopwatch.ElapsedTicks;
//stopwatch.Restart();


//// LINQ

//var linqCount = students.Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));
//var linqTicks = stopwatch.ElapsedTicks;

//stopwatch.Restart();

//// PLINQ

//var plinqCount = students.AsParallel().Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));

//var plinqTicks = stopwatch.ElapsedTicks;

//stopwatch.Stop();

//Console.WriteLine($"Parallel: {parallelFor}, count = {parallelCount}");
//Console.WriteLine($"Linq : {linqTicks}, count = {linqCount}");
//Console.WriteLine($"PLinq: {plinqTicks}, count = {plinqCount}");
//Console.ReadLine();
#endregion

#region PLINQ VS LINQ VS Parallel with list


#endregion


#region PLINQ VS LINQ VS Parallel with Thread Safe Collections
Stopwatch sw = new();
sw.Start();
ConcurrentBag<string> namesParallel = [];
object sync = new();
Parallel.ForEach(students, student =>
{
    if (student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
    {
        namesParallel.Add($"{student.FirstName}  {student.LastName}");
    }
});

var parallelTicks = sw.ElapsedTicks;
sw.Restart();

var namesLinq = students
    .Where(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
    .Select(student => $"{student.FirstName} {student.LastName}")
    .ToList();

var linqTicks = sw.ElapsedTicks;
sw.Restart();

var namesPLinq = students
    .AsParallel()
    .Where(student => student.FirstName.Length + student.LastName.Length > 15 && student.Email.ToLower().EndsWith("@gmail.com"))
    .Select(student => $"{student.FirstName} {student.LastName}")
    .ToList();
var pLinqTicks = sw.ElapsedTicks;
sw.Stop();
Console.WriteLine(namesParallel.Count);
Console.WriteLine(namesLinq.Count);
Console.WriteLine(namesPLinq.Count);

Console.WriteLine($"Linq Tick: {linqTicks} ");
Console.WriteLine($"Parallel tick: {parallelTicks}");
Console.WriteLine($"PLINQ tick: {pLinqTicks}");
#endregion