using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant
{
    public class RestaurantSystem : IOrderManagement
    {
        private List<MenuItem> menu;
        private List<Order> activeOrders;

        public RestaurantSystem()
        {
            menu = new List<MenuItem>();
            activeOrders = new List<Order>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            menu.Add(new Dish("Борщ", 120.00m, "Перше"));
            menu.Add(new Dish("Стейк з картоплею", 350.50m, "Друге"));
            menu.Add(new Dish("Салат Цезар", 180.00m, "Салат"));

            menu.Add(new Beverage("Кава", 60.00m, 200, false));
            menu.Add(new Beverage("Сік апельсиновий", 70.00m, 250, false));
            menu.Add(new Beverage("Вино червоне", 150.00m, 150, true));
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\n--- 📜 МЕНЮ РЕСТОРАНУ ---");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i].ToString()} | Деталі: {menu[i].GetDetails()}");
            }
            Console.WriteLine("---------------------------\n");
        }

        public MenuItem FindMenuItem(string query)
        {
            MenuItem itemByName = menu.FirstOrDefault(m => m.Name.Equals(query, StringComparison.OrdinalIgnoreCase));
            if (itemByName != null)
                return itemByName;

            return menu.OfType<Dish>()
                       .FirstOrDefault(d => d.DishCategory.Equals(query, StringComparison.OrdinalIgnoreCase));
        }


        public Order CreateOrder(int tableNumber)
        {
            Order newOrder = new Order(tableNumber);
            activeOrders.Add(newOrder);
            return newOrder;
        }

        public void AddItemToOrder(int orderId, string itemName)
        {
            Order order = FindOrderById(orderId);
            MenuItem item = FindMenuItem(itemName);

            if (order != null && item != null)
            {
                order.AddItem(item);
            }
            else if (order == null)
            {
                Console.WriteLine($"⚠️ Замовлення з ID {orderId} не знайдено.");
            }
            else // item == null
            {
                Console.WriteLine($"⚠️ Позиція '{itemName}' не знайдена в меню.");
            }
        }

        public void ChangeOrderStatus(int orderId, OrderStatus newStatus)
        {
            Order order = FindOrderById(orderId);
            if (order != null)
            {
                order.ChangeStatus(newStatus);
            }
            else
            {
                Console.WriteLine($"⚠️ Замовлення з ID {orderId} не знайдено.");
            }
        }

        public Order FindOrderById(int orderId)
        {
            return activeOrders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public void DisplayAllActiveOrders()
        {
            Console.WriteLine("\n--- 📋 УСІ АКТИВНІ ЗАМОВЛЕННЯ ---");
            if (!activeOrders.Any())
            {
                Console.WriteLine("Наразі немає активних замовлень.");
                Console.WriteLine("---------------------------------");
                return;
            }

            foreach (var order in activeOrders.Where(o => o.Status != OrderStatus.Paid))
            {
                Console.WriteLine($"ID: {order.OrderId} | Стіл: {order.TableNumber} | Статус: {order.Status} | Сума: {order.CalculateTotal():C}");
            }
            Console.WriteLine("---------------------------------");
        }
    }
}