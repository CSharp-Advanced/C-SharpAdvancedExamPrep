using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            data = new List<Ski>();
        }

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var targetManufacturer = data.FirstOrDefault(x => x.Manufacturer == manufacturer);
            var targetModel = data.FirstOrDefault(x => x.Model == model);

            if (targetManufacturer == null || targetModel == null)
            {
                return false;
            }

            data.Remove(targetModel);
            return true;
        }

        public Ski GetNewestSki()
        => data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model)
        {

            if (data.Count == 0)
            {
                return null;
            }
            foreach (var item in data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    return item;
                }
            }

            return null;
        }

        public string GetStatistics()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
