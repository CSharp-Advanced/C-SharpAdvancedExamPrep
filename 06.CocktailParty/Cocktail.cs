using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public IList<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;

            Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (Capacity > Ingredients.Count &&
                CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
            => Ingredients.Remove(Ingredients.FirstOrDefault(x => x.Name == name));

        public Ingredient FindIngredient(string name)
            => Ingredients.FirstOrDefault(x => x.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
            => Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            sb.AppendLine($"{string.Join(Environment.NewLine, Ingredients)}");
            return sb.ToString().TrimEnd();
        }
    }
}
