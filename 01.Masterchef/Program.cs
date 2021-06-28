using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(ParseArray());

            Stack<int> freshness = new Stack<int>(ParseArray());

            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0},
                { "Green salad", 0},
                { "Chocolate cake", 0},
                { "Lobster", 0}
            };

            while (ingredients.Any() && freshness.Any())
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int sum = ingredients.Peek() * freshness.Peek();

                switch (sum)
                {
                    case 150:
                        dishes["Dipping sauce"]++;
                        RemoveValues(ingredients, freshness);
                        break;
                    case 250:
                        dishes["Green salad"]++;
                        RemoveValues(ingredients, freshness);
                        break;
                    case 300:
                        dishes["Chocolate cake"]++;
                        RemoveValues(ingredients, freshness);
                        break;
                    case 400:
                        dishes["Lobster"]++;
                        RemoveValues(ingredients, freshness);
                        break;
                    default:
                        freshness.Pop();
                        int currentIngredient = ingredients.Dequeue();
                        currentIngredient += 5;
                        ingredients.Enqueue(currentIngredient);
                        break;
                }
            }
            PrintResult(ingredients, freshness, dishes);
        }

        public static string PrintResult(Queue<int> queue, Stack<int> stack, Dictionary<string, int> dictionary)
        {
            bool isSuccessful = false;
            int cookedDishes = 0;

            StringBuilder sb = new StringBuilder();

            foreach (var dish in dictionary)
            {
                cookedDishes += dish.Value;
            }

            if (cookedDishes >= 4)
            {
                isSuccessful = true;
            }

            if (isSuccessful)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (queue.Any())
            {
                Console.WriteLine($"Ingredients left: {queue.Sum()}");
            }

            foreach (var dish in dictionary.OrderBy(x => x.Key))
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static IEnumerable<int> ParseArray()
        => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

        public static void RemoveValues(Queue<int> queue, Stack<int> stack)
        {
            queue.Dequeue();
            stack.Pop();
        }
    }
}
