using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> food = new Dictionary<string, int>() {
                { "Bread",0},
                { "Cake",0},
                { "Pastry",0},
                { "Fruit Pie",0}
            };

            while (liquids.Any() && ingredients.Any())
            {
                int sum = liquids.Peek() + ingredients.Peek();

                switch (sum)
                {
                    case 25:
                        food["Bread"]++;
                        RemoveValues(liquids, ingredients);
                        break;
                    case 50:
                        food["Cake"]++;
                        RemoveValues(liquids, ingredients);
                        break;
                    case 75:
                        food["Pastry"]++;
                        RemoveValues(liquids, ingredients);
                        break;
                    case 100:
                        food["Fruit Pie"]++;
                        RemoveValues(liquids, ingredients);
                        break;
                    default:
                        liquids.Dequeue();
                        int increaseLiquid = ingredients.Pop();
                        increaseLiquid += 3;
                        ingredients.Push(increaseLiquid);
                        break;
                }
            }

            if (!liquids.Any() && !ingredients.Any())
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (!liquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }

            if (!ingredients.Any())
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var item in food.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void RemoveValues(Queue<int> liquids, Stack<int> ingredients)
        {
            liquids.Dequeue();
            ingredients.Pop();
        }
    }
}
