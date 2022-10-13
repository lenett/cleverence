using System;
using System.Threading;

namespace Task2
{
    public class AsyncCaller
    {
        ManualResetEvent mre;
        private EventHandler eventHandler;
        private int timeForWaiting;
        public delegate void TaskHandler();

        public bool Invoke(int _timeForWaiting, object? sender, EventArgs e)
        {
            timeForWaiting = _timeForWaiting;
            mre = new ManualResetEvent(false);
            Task task=new Task(() => ExecuteMethod());
            task.Start();

            Task waitingTask = new Task(() => WaitingTime());
            waitingTask.Start();

            mre.WaitOne();
            Thread.Sleep(1);

            return task.IsCompleted;
        }
        
        public AsyncCaller(EventHandler _eventHandler)
        {
            eventHandler = _eventHandler;
        }

        private void WaitingTime()
        {
            Thread.Sleep(timeForWaiting);
            mre.Set();
            Console.WriteLine(1);
        }

        private void ExecuteMethod()
        {
            EventHandler h = eventHandler;
            h.Invoke(null, EventArgs.Empty);
            mre.Set();
        }

    }

    public class AsyncCaller1
    {
        public Task eventHandler;

        public AsyncCaller1(Task _eventHandler)
        {
            eventHandler= _eventHandler;
        }

        public async Task<bool> Invoke(int _timeForWaiting)
        {
            eventHandler.Start();
            var saf = await Task.WhenAny(eventHandler, Task.Delay(_timeForWaiting));
            return eventHandler.IsCompleted;
        }

      
    }

    
}
