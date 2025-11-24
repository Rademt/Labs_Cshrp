using System.Collections.Generic;

namespace Restaurant
{
    public interface IOrderManagement
    {
        Order CreateOrder(int tableNumber);
        void AddItemToOrder(int orderId, string itemName);
        void ChangeOrderStatus(int orderId, OrderStatus newStatus);
        Order FindOrderById(int orderId);
        void DisplayAllActiveOrders();
    }
}