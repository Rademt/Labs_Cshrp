using System;
using System.Linq;
using System.Collections.Generic;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RestaurantSystem system = new RestaurantSystem();

            system.DisplayMenu();

            Console.WriteLine("### Демонстрація Замовлення №1 (Стіл 5) ###");
            Order order1 = system.CreateOrder(5);
            int orderId1 = order1.OrderId;

            system.AddItemToOrder(orderId1, "Борщ");
            system.AddItemToOrder(orderId1, "Кава");
            system.AddItemToOrder(orderId1, "Вино червоне");
            system.AddItemToOrder(orderId1, "Неіснуюча позиція");

            Console.WriteLine($"Поточна сума замовлення №{orderId1}: {order1.CalculateTotal():C}");

            system.ChangeOrderStatus(orderId1, OrderStatus.InProgress);
            system.ChangeOrderStatus(orderId1, OrderStatus.Ready);
            order1.RemoveItem("Вино червоне");
            Console.WriteLine($"Нова сума замовлення №{orderId1} після видалення: {order1.CalculateTotal():C}");
            order1.DisplayOrderSummary();
            system.ChangeOrderStatus(orderId1, OrderStatus.Paid);

            Console.WriteLine("\n### Демонстрація Замовлення №2 (Стіл 8) ###");
            Order order2 = system.CreateOrder(8);
            int orderId2 = order2.OrderId;
            system.AddItemToOrder(orderId2, "Стейк з картоплею");
            system.AddItemToOrder(orderId2, "Сік апельсиновий");
            system.ChangeOrderStatus(orderId2, OrderStatus.InProgress);
            order2.DisplayOrderSummary();


            Console.WriteLine("\n### Облік та пошук ###");
            system.DisplayAllActiveOrders();

            Order foundOrder = system.FindOrderById(orderId2);
            if (foundOrder != null)
            {
                Console.WriteLine($"Пошук за ID {orderId2} успішний. Статус: {foundOrder.Status}");
            }
            system.FindOrderById(9999);

            MenuItem foundItem = system.FindMenuItem("Перше");
            if (foundItem != null)
            {
                Console.WriteLine($"Пошук позиції за категорією 'Перше' успішний: {foundItem.Name}");
            }

            Console.WriteLine("\n### Демонстрація Upcast/Downcast ###");

            MenuItem upcastedItem = new Beverage("Лимонад", 45.00m, 300, false);
            Console.WriteLine($"Upcast (як MenuItem): {upcastedItem.GetDetails()}");

            if (upcastedItem is Beverage)
            {
                Beverage downcastedBeverage = (Beverage)upcastedItem;
                Console.WriteLine($"Downcast (як Beverage): Об'єм - {downcastedBeverage.VolumeMl} мл");
            }

            Dish dishItem = system.FindMenuItem("Салат Цезар") as Dish;
            if (dishItem != null)
            {
                Console.WriteLine($"Downcast 'Салат Цезар' (як Dish): Категорія - {dishItem.DishCategory}");
            }
        }
    }
}