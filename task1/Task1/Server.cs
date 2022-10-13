
namespace Task1
{
    static class Server
    {
        private static RWLock rwLock = new RWLock();
        private static int count = 0;

        public static int GetCount()
        {
            using (rwLock.ReadLock())
            {
                return count;
            }
        }

        public static void AddToCount(int value)
        {

            using (rwLock.WriteLock())
            {
                count += value;
            }
        }
    }
}
