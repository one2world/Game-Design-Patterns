using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game_Design_Patterns._1创建型._1单例
{
    public class Singleton2
    {
        private static Singleton2 s_instance = null;
        private Singleton2() { }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Singleton2 GetInstance()
        {
            if (s_instance == null)
            {
                s_instance = new Singleton2();
            }
            return s_instance;
        }

    }
}
