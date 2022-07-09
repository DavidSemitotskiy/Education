using System;

namespace LSP
{
    public abstract class Bird
    {
        public abstract void Fly();
    }

    public class Duck : Bird
    {
        public override void Fly() => Console.WriteLine("Duck flies, quack-quack!");
    }

    public class Colibri : Bird
    {
        public override void Fly() => Console.WriteLine("Colibri flies very fast");
    }

    public class Ostrich : Bird
    {
        public override void Fly() => throw new NotSupportedException("Ostrich can't fly");
    }

    public class Penguin : Bird
    {
        public override void Fly() => throw new InvalidOperationException("Penguin: - I wish I could, but...");
    }
}
