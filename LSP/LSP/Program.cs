using System;
using System.Linq;

namespace LSP
{
    class Program
    {
        private static void Main()
        {
            var birds = new Bird[]
            {
                new Duck(),
                new Colibri(),
                new Penguin(),
                new Ostrich()
            };

            WaveBirdsWave(birds);
            Console.WriteLine();
            var sortResult = birds.OfType<FlyingBird>().ToArray();
            FlyBirdsFly(sortResult);
        }

        public static void WaveBirdsWave(Bird[] birds)
        {
            foreach (var bird in birds)
            {
                bird.WaveWing();
            }
        }

        public static void FlyBirdsFly(FlyingBird[] birds)
        {
            foreach (var bird in birds)
            {
                bird.Fly();
            }
        }
    }
}
