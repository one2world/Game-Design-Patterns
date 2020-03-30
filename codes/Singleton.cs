using System;
public class Singleton<T> where T : new()
{
    private static T instance = new T();
    public static T Instance{
        get{return instance;}
    }
}


public class Emperor: Singleton<Emperor>
{
    public void Say()
    {
        Console.WriteLine("i'm Emperor, my hash is "+ this.GetHashCode());
    }
}