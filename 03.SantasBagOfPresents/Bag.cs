using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int MyProperty { get; set; }
        public int Count => data.Count();
        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;

            data = new List<Present>();
        }

        public void Add(Present present)
        {
            if (Capacity != 0 && !data.Contains(present))
            {
                data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var target = data.FirstOrDefault(x => x.Name == name);

            if (target == null)
            {
                return false;
            }

            data.Remove(target);

            return true;
        }

        public Present GetHeaviestPresent()
        {
            int maxWeight = int.MinValue;

            Present heaviestPresent = null;

            foreach (var present in data)
            {
                if (present.Weight > maxWeight)
                {
                    heaviestPresent = present;
                }
            }

            return heaviestPresent;
        }

        public Present GetPresent(string name)
        {
            Present target = data.First(x => x.Name == name);
            return target;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Color} bag contains:");

            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
