using System;
using System.Linq;
using System.Reflection;

namespace Ex2Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetAssembly(typeof(object));

            var obsoleteClasses = assembly?.GetTypes().Where(x => x.GetCustomAttributes<ObsoleteAttribute>().Any());

            if (obsoleteClasses is null) return;

            foreach (var obsoleteClass in obsoleteClasses)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"Class: {obsoleteClass.Name}");

                Console.ForegroundColor = default;

                foreach (var method in obsoleteClass.GetMethods())
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{obsoleteClass.FullName}.{method.Name}()");
                }
            }
        }
    }
}
