using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> materialsStack = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> magicQueue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> presents = new Dictionary<string, int>() {
                { "Doll",0},
                { "Wooden train",0},
                { "Teddy bear",0},
                { "Bicycle",0}
            };

            while (materialsStack.Any() && magicQueue.Any())
            {
                if (materialsStack.Peek() == 0 || magicQueue.Peek() == 0)
                {
                    if (materialsStack.Peek() == 0)
                    {
                        materialsStack.Pop();
                    }

                    if (magicQueue.Peek() == 0)
                    {
                        magicQueue.Dequeue();
                    }

                    continue;
                }

                int sum = materialsStack.Peek() * magicQueue.Peek();

                switch (sum)
                {
                    case 150:
                        presents["Doll"]++;
                        RemoveValues(materialsStack, magicQueue);
                        break;
                    case 250:
                        presents["Wooden train"]++;
                        RemoveValues(materialsStack, magicQueue);
                        break;
                    case 300:
                        presents["Teddy bear"]++;
                        RemoveValues(materialsStack, magicQueue);
                        break;
                    case 400:
                        presents["Bicycle"]++;
                        RemoveValues(materialsStack, magicQueue);
                        break;
                    default:
                        if (sum < 0)
                        {
                            int add = materialsStack.Pop() + magicQueue.Dequeue();
                            materialsStack.Push(add);
                        }
                        else
                        {
                            magicQueue.Dequeue();
                            int increased = materialsStack.Pop();
                            increased += 15;
                            materialsStack.Push(increased);
                        }
                        break;
                }
            }
            Console.WriteLine(PrintResult(presents, materialsStack, magicQueue));
        }
        private static void RemoveValues(Stack<int> stack, Queue<int> queue)
        {
            stack.Pop();
            queue.Dequeue();
        }

        public static string PrintResult(Dictionary<string, int> dictionary, Stack<int> stack, Queue<int> queue)
        {
            dictionary = dictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            int craftedNum = 0;
            StringBuilder sb = new StringBuilder();

            foreach (var toy in dictionary)
            {
                craftedNum += toy.Value;
            }

            if (craftedNum > 0)
            {
                sb.AppendLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                sb.AppendLine("No presents this Christmas!");
            }

            if (stack.Any())
            {
                sb.AppendLine($"Materials left: { string.Join(", ", stack)}");
            }

            if (queue.Any())
            {
                sb.AppendLine($"Magic left: {string.Join(", ", queue)}");
            }

            foreach (var toy in dictionary)
            {
                if (toy.Value>0)
                {
                    sb.AppendLine($"{toy.Key}: {toy.Value}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
