using System;

namespace LSP
{
    public abstract class Bird
    {
        public abstract void WaveWing();

    }
    public abstract class FlyingBird : Bird
    {
        public abstract void Fly();
    }

    public class Duck : FlyingBird
    {
        public override void Fly() => Console.WriteLine("Duck flies, quack-quack!");

        public override void WaveWing() => Console.WriteLine("Duck: I wave very powerfully");
    }

    public class Colibri : FlyingBird
    {
        public override void Fly() => Console.WriteLine("Colibri flies very fast");

        public override void WaveWing() => Console.WriteLine("Colibri: I wave very fast");
    }

    public class Ostrich : Bird
    {
        public override void WaveWing() => Console.WriteLine("Ostrich: I wave very slowly");
    }

    public class Penguin : Bird
    {
        public override void WaveWing() => Console.WriteLine("Penguin: I wave to swim under water");
    }
}
