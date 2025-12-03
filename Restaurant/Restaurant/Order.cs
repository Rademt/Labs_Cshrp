using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant
{
    public class Order
    {
        private static int nextOrderId = 1000;

        // Інкапсуляція
        public int OrderId { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }
        private List<MenuItem> items;

        public Order(int tableNumber)
        {
            OrderId = nextOrderId++;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
            items = new List<MenuItem>();
            Console.WriteLine($"\n Створено нове замовлення №{OrderId} для столика №{TableNumber}.");
        }

        public IReadOnlyList<MenuItem> Items => items.AsReadOnly();

        public void AddItem(MenuItem item)
        {
            items.Add(item);
            Console.WriteLine($"+ Додано позицію: {item.Name}");
        }

        public bool RemoveItem(string itemName)
        {
            MenuItem itemToRemove = items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                Console.WriteLine($"- Видалено позицію: {itemName}");
                return true;
            }
            return false;
        }

        public decimal CalculateTotal()
        {
            return items.Sum(item => item.Price);
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            if (newStatus > Status)
            {
                Console.WriteLine($"> Змінено статус замовлення №{OrderId}: {Status} → {newStatus}");
                Status = newStatus;
            }
            else
            {
                Console.WriteLine($"Невдала спроба змінити статус замовлення №{OrderId} з {Status} на {newStatus}. Перехід назад не дозволено.");
            }
        }

        public void DisplayOrderSummary()
        {
            Console.WriteLine($"\n--- Замовлення №{OrderId} ---");
            Console.WriteLine($"Стіл: {TableNumber}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine($"Сума: {CalculateTotal():C}");
            if (items.Any())
            {
                Console.WriteLine("Позиції:");
                foreach (var item in items)
                {
                    Console.WriteLine($"  - {item.Name} ({item.Price:C})");
                }
            }
            else
            {
                Console.WriteLine("Позиції: Замовлення порожнє.");
            }
            Console.WriteLine("-----------------------");
        }
    }
}
