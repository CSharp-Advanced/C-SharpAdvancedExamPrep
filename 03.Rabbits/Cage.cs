using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            data = new List<Rabbit>();
        }

        public void Add(Rabbit rabbit)
        {
            if (Capacity != 0 && !data.Contains(rabbit))
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var target = data.FirstOrDefault(x => x.Name == name);

            if (target == null)
            {
                return false;
            }

            data.Remove(target);
            return true;
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var target = data.First(x => x.Name == name);
            target.Available = false;
            return target;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbits = data.Where(x => x.Species == species).ToArray();

            foreach (var rabbit in rabbits)
            {
                rabbit.Available = false;
            }

            return rabbits;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {Name}:");

            foreach (var rabbit in data)
            {
                if (rabbit.Available==true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
