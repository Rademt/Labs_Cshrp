using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Dish : MenuItem
    {
        public string DishCategory { get; private set; }

        public Dish(string name, decimal price, string dishCategory)
            : base(name, price)
        {
            DishCategory = dishCategory;
            Category = "Страва";
        }

        public override string GetDetails()
        {
            return $"Страва: {Name}, Категорія: {DishCategory}, Ціна: {Price:C}";
        }
    }
}
