using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public IList<Employee> Employees { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            Employees = new List<Employee>();
        }

        public void Add(Employee employee) { 
        
        }
    }
}
