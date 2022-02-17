using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game_Design_Patterns._1创建型._1单例
{
    public class Singleton3
    {
        private static object lockObj = new object();
        private static Singleton3 s_instance = null;
        private Singleton3() { }

        public static Singleton3 GetInstance()
        {
            if (s_instance == null)
            {
                lock (lockObj)
                {
                    if (s_instance == null)
                    {
                        s_instance = new Singleton3();
                    }
                }
            }
            return s_instance;
        }

    }

}
