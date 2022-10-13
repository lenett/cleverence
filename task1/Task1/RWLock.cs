namespace Task1
{
    class RWLock : IDisposable
    {
        public struct WriteLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim locker;
            public WriteLockToken(ReaderWriterLockSlim _locker)
            {
                locker = _locker;
                locker.EnterWriteLock();
            }
            public void Dispose() => locker.ExitWriteLock();
        }

        public struct ReadLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim locker;
            public ReadLockToken(ReaderWriterLockSlim _locker)
            {
                locker = _locker;
                locker.EnterReadLock();
            }
            public void Dispose() => locker.ExitReadLock();
        }

        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        public ReadLockToken ReadLock() => new ReadLockToken(locker);
        public WriteLockToken WriteLock() => new WriteLockToken(locker);

        public void Dispose() => locker.Dispose();
    }
}
