// async inside
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

Console.WriteLine($"Main Method start in thread: {Thread.CurrentThread.ManagedThreadId}");
SomeClass someClass = new();

//someClass.SomeMethod();
someClass.SomeMethodAsync();

Console.ReadLine();

class SomeClass
{
    public void SomeMethod()
    {
        Console.WriteLine($"SomeMethod start in thread: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Begin");
        Thread.Sleep(2000);
        Console.WriteLine("End");
    }

    public void SomeMethodAsync()
    {
        AsyncStateMachine stateMachine = new AsyncStateMachine();
        stateMachine.outer = this;
        stateMachine.builder = AsyncVoidMethodBuilder.Create();
        stateMachine.state = -1;
        stateMachine.builder.Start(ref stateMachine);
        
    }
}

struct AsyncStateMachine : IAsyncStateMachine
{
    public int state;
    public SomeClass outer;
    private TaskAwaiter awaiter;
    public AsyncVoidMethodBuilder builder;
    public void MoveNext()
    {
        if(state == -1)
        {
            Console.WriteLine($"Start threadId: {Thread.CurrentThread.ManagedThreadId}");
            Task t = Task.Factory.StartNew(outer.SomeMethod);
            awaiter = t.GetAwaiter();
            state = 0;
            builder.AwaitOnCompleted(ref awaiter, ref this);
        }
        else if(state == 0)
        {
            Console.WriteLine($"End threadId: {Thread.CurrentThread.ManagedThreadId}");            
        }

    }

    public void SetStateMachine(IAsyncStateMachine stateMachine)
    {
        builder.SetStateMachine(stateMachine);
    }
}