using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Task2;

namespace Task2UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAsyncCallMetod1()
        {
            EventHandler h = new EventHandler(Wait);
            var ac = new AsyncCaller(h);
            bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);
            Assert.AreEqual(true, completedOK);
        }

        [TestMethod]
        public void TestAsyncCallMetod2()
        {
            EventHandler h = new EventHandler(Wait);
            var ac = new AsyncCaller(h);
            bool completedOK = ac.Invoke(2000, null, EventArgs.Empty);
            Assert.AreEqual(false, completedOK);
        }

        [TestMethod]
        public void TestAsyncCallMetod3()
        {
            EventHandler h = new EventHandler(Wait);
            var ac = new AsyncCaller(h);
            bool completedOK = ac.Invoke(7000, null, EventArgs.Empty);
            Assert.AreEqual(true, completedOK);
        }

        [TestMethod]
        public void TestAsyncCall1Metod1()
        {
  
            Task eventHandler = new Task(() => Wait(null, EventArgs.Empty));
            var ac = new AsyncCaller1(eventHandler);
            bool completedOK = ac.Invoke(5000).Result;
            Assert.AreEqual(true, completedOK);
        }

        [TestMethod]
        public void TestAsyncCall1Metod2()
        {
            Task eventHandler = new Task(() => Wait(null, EventArgs.Empty));
            var ac = new AsyncCaller1(eventHandler);
            bool completedOK = ac.Invoke(2000).Result;
            Assert.AreEqual(false, completedOK);
        }

        [TestMethod]
        public void TestAsyncCall1Metod3()
        {
            Task eventHandler = new Task(() => Wait(null, EventArgs.Empty));
            var ac = new AsyncCaller1(eventHandler);
            bool completedOK = ac.Invoke(7000).Result;
            Assert.AreEqual(true, completedOK);
        }

        private void Wait(object? obj, EventArgs eventArgs)
        {
            Thread.Sleep(5000);
        }
    }
}