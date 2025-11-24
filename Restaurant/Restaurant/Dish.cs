using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Dish : MenuItem
    {
        public string DishCategory { get; private set; } // Наприклад, Перше, Друге, Салат

        public Dish(string name, decimal price, string dishCategory)
            : base(name, price)
        {
            DishCategory = dishCategory;
            Category = "Страва"; // Встановлення базової категорії
        }

        public override string GetDetails()
        {
            return $"Страва: {Name}, Категорія: {DishCategory}, Ціна: {Price:C}";
        }
    }
}
