using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hatStack = new Stack<int>(ParseArray());
            Queue<int> scarfQueue = new Queue<int>(ParseArray());
            List<int> set = new List<int>();

            while (hatStack.Any() && scarfQueue.Any())
            {
                int currentHat = hatStack.Peek();
                int currentScarf = scarfQueue.Peek();

                if (currentHat>currentScarf)
                {
                    set.Add(hatStack.Pop() + scarfQueue.Dequeue());
                }
                else if(currentHat<currentScarf)
                {
                    hatStack.Pop();
                }
                else
                {
                    scarfQueue.Dequeue();
                    int increment = hatStack.Pop();
                    increment++;
                    hatStack.Push(increment);
                }
            }

            Console.WriteLine($"The most expensive set is: {set.Max()}");
            Console.WriteLine(string.Join(' ',set));
        }

        private static IEnumerable<int> ParseArray()
        => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
    }
}
