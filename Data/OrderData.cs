using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Data;

public static class OrderData
{
    public static List<Order> Orders = new List<Order>
    {
        new Order { Id = 1, Address = "ул. Ленина, 10", DishId = 1, CourierId = 1, TotalPrice = 450, Status = "В пути" },
        new Order { Id = 2, Address = "пр. Мира, 25", DishId = 2, CourierId = 2, TotalPrice = 599, Status = "Доставлен" }
    };

    public static void Add(Order order)
    {
        order.Id = Orders.Any() ? Orders.Max(o => o.Id) + 1 : 1;
        Orders.Add(order);
    }

    public static Order? GetById(int id) => Orders.FirstOrDefault(o => o.Id == id);
}