using Game_Design_Patterns._1创建型._1单例;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PatternCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // SingletonTest();
            // SingletonMuliThreadTest();
            // FactoryTest();
            // SimpleFactoryTest();
            // AbstractFactoryTest();
            //SingletonFactoryTest();
            TestInstanceProfile();
            Console.ReadKey();
        }

        public static void TestInstanceProfile()
        {
            int count = 100000;
            long es = 0;
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                var va = Singleton1.GetInstance();
            }
            watch.Stop();
            es = watch.ElapsedTicks;
            Console.WriteLine($"1 耗时 {es}");

            watch.Restart();
            for (int i = 0; i < count; i++)
            {
                var va = Singleton2.GetInstance();
            }
            watch.Stop();
            es = watch.ElapsedTicks;
            Console.WriteLine($"2 耗时 {es}");

            watch.Restart();
            for (int i = 0; i < count; i++)
            {
                var va = Singleton3.GetInstance();
            }
            watch.Stop();
            es = watch.ElapsedTicks;
            Console.WriteLine($"3 耗时 {es}");

            watch.Restart();
            for (int i = 0; i < count; i++)
            {
                var va = Singleton4.GetInstance();
            }
            watch.Stop();
            es = watch.ElapsedTicks;
            Console.WriteLine($"4 耗时 {es}");
            
        }

        public static void TestInstance2Unique()
        {
            for (int i = 0; i < 5; i++)
            {


                int threadCount = 10000;
                Task<int>[] tasks = new Task<int>[threadCount];
                for (int j = 0; j < threadCount; j++)
                {
                    tasks[j] = Task.Run<int>(() =>
                    {
                        return Singleton2.GetInstance().GetHashCode();
                    });
                }
                Task.WaitAll(tasks);

                var codes = tasks.Select(t => t.Result).Distinct();
                Debug.Assert(codes.Count()== 1, $"Singleton2非单例 {codes.Count()}");
            }
        }

        public static void TestInstance3Unique()
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
                Debug.Assert(codes.Count() == 1, $"Singleton3非单例 {codes.Count()}");
            }
        }

        #region 单例测试
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
#endregion
#region 工厂模式测试
        private static void FactoryTest()
        {
            AbstractHumanFactory factory = new HumanFactory();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create White human：");
            var hummanWhite = factory.CreateHuman<WhiteHuman>();
            hummanWhite.GetColor();
            hummanWhite.Talk();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create Yellow human：");
            var hummanYellow = factory.CreateHuman<YellowHuman>();
            hummanYellow.GetColor();
            hummanYellow.Talk();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create Black human：");
            var hummanBlack = factory.CreateHuman<BlackHuman>();
            hummanBlack.GetColor();
            hummanBlack.Talk();
        }
#endregion

#region 简单工厂模式测试
        private static void SimpleFactoryTest()
        {
            Console.WriteLine("SimpleFactory test");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create White human：");
            var hummanWhite = HumanSimpleFactory.CreateHuman<WhiteHuman>();
            hummanWhite.GetColor();
            hummanWhite.Talk();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create Yellow human：");
            var hummanYellow = HumanSimpleFactory.CreateHuman<YellowHuman>();
            hummanYellow.GetColor();
            hummanYellow.Talk();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create Black human：");
            var hummanBlack = HumanSimpleFactory.CreateHuman<BlackHuman>();
            hummanBlack.GetColor();
            hummanBlack.Talk();
        }
#endregion


#region 抽象工厂
       private static void AbstractFactoryTest()
        {
            Console.WriteLine("AbstractFactory test");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create White human：");
            var hummanWhite = new WhiteHumanFactory().CreateHuman();
            hummanWhite.GetColor();
            hummanWhite.Talk();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create Yellow human：");
            var hummanYellow = new YellowHumanFactory().CreateHuman();
            hummanYellow.GetColor();
            hummanYellow.Talk();

            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Create Black human：");
            var hummanBlack = new BlackHumanFactory().CreateHuman();
            hummanBlack.GetColor();
            hummanBlack.Talk();
        }
#endregion

#region SingletonFactory
        private static void SingletonFactoryTest()
        {
            SingletonFactory.GetInstance().SayHello();
        }
#endregion
    }
}
