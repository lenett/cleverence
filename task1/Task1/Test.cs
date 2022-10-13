
namespace Task1
{
    public static class Test
    {
        public static void StartThreadsForReading(int countTreads)
        {
            for (int i = 0; i < countTreads; i++)
            {
                Task task = Task.Run(() => LogCount());
            }
        }

        public static void StartThreadsForWriting(int countTreads)
        {
            for (int i = 0; i < countTreads; i++)
            {
                
                Task task = new Task(() => AddToCount(i));
                task.Start();
                Thread.Sleep(1000);
            }
        }

        private static void LogCount()
        {
            Console.WriteLine(String.Format("thread {0}, value {1}" , Task.CurrentId, Server.GetCount()));
        }

        private static void AddToCount(int value)
        {
            Console.WriteLine(value);
            Server.AddToCount(value);
        }

    }
}
