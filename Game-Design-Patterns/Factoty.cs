using System;
using System.Reflection;

public interface IHuman
{
    void GetColor();
    void Talk();
}

public class BlackHuman: IHuman
{
    public void GetColor()
    {
        Console.WriteLine("BackHuman' color is black!");
    }

    public void Talk()
    {
        Console.WriteLine("BlackHuman say ￥#%#@%%##￥， what。。（听不懂）");
    }
}

public class YellowHuman: IHuman
{
    public void GetColor()
    {
        Console.WriteLine("YellowHuman' color is ywllow!");
    }

    public void Talk()
    {
        Console.WriteLine("BlackHuman say 你好啊！");
    }
}

public class WhiteHuman: IHuman
{
    public void GetColor()
    {
        Console.WriteLine("WhiteHuman' color is white!");
    }

    public void Talk()
    {
        Console.WriteLine("WhiteHuman say hello!");
    }
}

/*
工厂是new对象的替代品，包装了new, 也可以对其进行初始化等操作
*/
public abstract class AbstractHumanFactory
{
    public  abstract  IHuman CreateHuman<T>() where T : IHuman ,new();
}


public class HumanFactory: AbstractHumanFactory
{
    public override IHuman CreateHuman<T>()
    {
        IHuman human = null;
        try{
            human = (IHuman)(new T());
        }catch(Exception e)
        {
            Console.WriteLine("Create Human error, "+ e);
        }
        return human;
    }
}

#region SimpleFactory 简单工厂

public class HumanSimpleFactory
{

    public static IHuman CreateHuman<T>() where T : IHuman ,new()
    {
        IHuman human = null;
        try
        {
            human = (IHuman)(new T());
        }catch(Exception e)
        {
            Console.WriteLine("Create Human error, "+ e);
        }
        return human;
    }
}

#endregion

#region AbstractFactory 抽象工厂
public abstract class AbstractHumanFactory2
{
    public  abstract  IHuman CreateHuman();
}

public class WhiteHumanFactory:AbstractHumanFactory2
{
    public override IHuman CreateHuman()
    {
        return new WhiteHuman();
    }
}

public class YellowHumanFactory:AbstractHumanFactory2
{
    public override IHuman CreateHuman()
    {
        return new YellowHuman();
    }
}

public class BlackHumanFactory:AbstractHumanFactory2
{
    public override IHuman CreateHuman()
    {
        return new BlackHuman();
    }
}
#endregion

#region SingletonFactory

public class SingletonClass
{
    private SingletonClass()
    {}
    public void SayHello()
    {
        Console.WriteLine("ooooooooooooooooooo ");
    }
}

public class SingletonFactory
{
    public readonly static SingletonClass instance;
    public static SingletonClass GetInstance()
    {
        return instance;
    }
    static SingletonFactory()
    {
        var b_instance = typeof(SingletonClass).InvokeMember("SingletonClass", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, null, new object[]{});
        instance = (SingletonClass)b_instance;
    }
}
#endregion

