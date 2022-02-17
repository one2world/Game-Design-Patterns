using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game_Design_Patterns._1创建型._1单例
{
    public class Singleton4
    {
        private static class InstanceClass
        {
            internal static Singleton4 s_instance = new Singleton4();
        }
        private Singleton4() { }
        

        public static Singleton4 GetInstance()
        {
            return InstanceClass.s_instance;
        }

    }

}
