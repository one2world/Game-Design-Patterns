using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Design_Patterns._1创建型._1单例
{
    public class Singleton1
    {
        private static Singleton1 s_instance = new Singleton1();
        private Singleton1() { }

        public static Singleton1 GetInstance() { return s_instance; }

    }
}
