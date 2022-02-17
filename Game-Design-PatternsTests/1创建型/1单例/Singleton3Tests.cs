using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_Design_Patterns._1创建型._1单例;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Design_Patterns._1创建型._1单例.Tests
{
    [TestClass()]
    public class Singleton3Tests
    {
        [TestMethod()]
        public void GetInstanceTest()
        {
            for (int i = 0; i < 5; i++)
            {
                int threadCount = 10000;
                Task<int>[] tasks = new Task<int>[threadCount];
                for (int j = 0; j < threadCount; j++)
                {
                    tasks[j] = Task.Run<int>(() =>
                    {
                        return Singleton3.GetInstance().GetHashCode();
                    });
                }
                Task.WaitAll(tasks);

                var codes = tasks.Select(t => t.Result).Distinct();
                Assert.AreEqual(codes.Count(), 1, $"Singleton3非单例 {codes.Count()}");
            }
        }
    }
}