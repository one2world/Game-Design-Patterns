# Game-Design-Patterns

设计模式学习记录

---

## 《headfirst设计模式》

### 1. 策略模式

* 鸭子游戏引申的问题
  1. 基类实现——---》 导致所有集成类同接口的实现一致
  2. 基类实现 virtual（实现默认的），子类实现具体特殊的功能-----》 改一处可能需要修改的地方很多
  3. 都是用接口组合 --> 很多代码重复

> 把会变化的部分取出来并封装起来，以便于以后轻易地改动或者扩充此部分而不影响不需要变化的部分

``` c# 
    public class Duck{
        // ...
        QuackBehaviour quackBehaviour;
        FlyBehaviour flyBehaviour;

        public void SetQuackBehaviour(QuackBehaviour quackBehaviour)
        {
            this.quackBehaviour = quackBehaviour;
        }

        public void SetFlyBehaviour(FlyBehaviour flyBehaviour)
        {
            this.flyBehaviour = flyBehaviour;
        }

        public void Quack()
        {
            quackBehaviour.Quack();
        }

        public void Fly()
        {
            quackBehaviour.Fly();
        }
    }

    //变化部分
    public interface QuackBehaviour{
        void Quack();
    }

    public interface FlyBehaviour{
        void Fly();
    }
```

```c#
    //实现需要改动地方
    public class FlyWithWing
    {
        public void Fly()
        {
            // fly
        }
    }

    public class FlyNoWing
    {
        public void Fly()
        {
            // Empty
        }
    }

    //实现需要改动地方
    public class DuckQuack
    {
        public void Quack()
        {
            // 呱呱叫
        }
    }

    public class Squeak
    {
        public void Quack()
        {
            // 吱吱叫
        }
    }

    public class MuteQuack
    {
        public void Quack()
        {
            // 不会叫
        }
    }
```

> 设计原则： 有一个比是一个更好，多用组合少用继承。针对接口编程不针对实现编程。

* 以上使用的是**策略模式: 定义了算法族，分别封装起来，让他们之间相互替换，此模式让算法的变化独立于使用算法的客户**


### 2. 观察者模式(Observer)

