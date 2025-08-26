using System.Diagnostics;
// Processes


//Process.Start("calc");
//Process.Start("calc");
//Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");

//Console.WriteLine(Process.GetCurrentProcess().ProcessName);
//Console.WriteLine(Process.GetCurrentProcess().Id);
//Console.WriteLine(Process.GetCurrentProcess().BasePriority);

//var process = Process.GetProcessById(36308); // Process Id dinamicheski videlyayetsya OS i kajdiy raz mojet bit raznim

//Console.ReadLine();

//process.Kill();

//var processes = Process.GetProcessesByName("CalculatorApp");

//foreach (var proc in processes)
//{
//    Console.WriteLine($"{proc.Id} - {proc.ProcessName} - {proc.Threads.Count}");
//    proc.Kill();
//}

//var allProcesses = Process.GetProcesses();

//foreach (var proc in allProcesses)
//{
//    Console.WriteLine($"{proc.Id} - {proc.ProcessName} - {proc.Threads.Count}");
//}

//var current = Process.GetCurrentProcess();
//current.PriorityClass = ProcessPriorityClass.High;

ProcessStartInfo process = new ProcessStartInfo("calc");

Process.Start(process);
Console.WriteLine(process.WorkingDirectory);
Console.ReadLine();