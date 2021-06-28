using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> taskStack = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> threadQueue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            
            int value = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentTask = taskStack.Peek();
                int currentThread = threadQueue.Peek();

                if (currentTask== value)
                {
                    break;
                }

                if (currentThread>= currentTask)
                {
                    taskStack.Pop();
                    threadQueue.Dequeue();
                }
                else
                {
                    threadQueue.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threadQueue.Peek()} killed task {value}");
            Console.WriteLine(string.Join(' ', threadQueue));
        }
    }
}
