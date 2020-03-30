using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatternCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // SingletonTest();
            SingletonMuliThreadTest();
        }

        private static void SingletonTest()
        {   
            HashSet<int> emperorSet = new HashSet<int>();
            for(int i = 0; i< 1000; i++)
            {
                var emperor = Emperor.Instance;
                emperor.Say();
                emperorSet.Add(emperor.GetHashCode());
            }

            Console.WriteLine("Emperor Count: "+ emperorSet.Count);
        }

        private static void SingletonMuliThreadTest()
        {   
            HashSet<int> emperorSet = new HashSet<int>();
            
            Task[] tasks = new Task[1000];
            for(int i = 0; i< 1000; i++)
            {
                Task t = new Task(()=>{

                    int j = 100;
                    while(j-->0)
                    {
                        Console.WriteLine("Task"+ System.Threading.Thread.CurrentThread.ManagedThreadId);
                        var emperor = Emperor.Instance;
                        emperor.Say();
                        emperorSet.Add(emperor.GetHashCode());
                    }
                });
                t.Start();
                tasks[i] = t;
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Emperor Count: "+ emperorSet.Count);
        }
    }
}
