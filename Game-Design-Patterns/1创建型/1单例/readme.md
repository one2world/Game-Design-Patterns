#四种单例一万次Tick

Singleton1 耗时 13461
Singleton2 耗时 32878
Singleton3 耗时 16467
Singleton4 耗时 18332

简单粗暴的性能最好,其次是双重验证,然后是静态内部类,最差是全Lock。