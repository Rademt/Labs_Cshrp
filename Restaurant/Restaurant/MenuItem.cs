using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public abstract class MenuItem
    {
        // Інкапсуляція
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; protected set; }
        protected MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public abstract string GetDetails();

        public override string ToString()
        {
            return $"{Name} ({Category}) - {Price:C}";
        }
    }
}
