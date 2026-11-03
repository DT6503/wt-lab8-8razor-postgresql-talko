using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Data;

public static class CourierData
{
    private static List<Courier> _couriers = new List<Courier>
    {
        new Courier(1, "Александр Петров", "+7 (999) 111-22-33")
        {
            ImageUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=400&fit=crop&crop=faces",
            Vehicle = "Автомобиль",
            Rating = 4.9m,
            DeliveriesCount = 1248,
            Description = "Опытный курьер. Работает в службе более 3 лет. Всегда вежлив и пунктуален."
        },
        new Courier(2, "Мария Иванова", "+7 (999) 444-55-66")
        {
            ImageUrl = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=400&h=400&fit=crop&crop=faces",
            Vehicle = "Скутер",
            Rating = 5.0m,
            DeliveriesCount = 892,
            Description = "Быстрая и аккуратная доставка. Специализируется на срочных заказах."
        },
        new Courier(3, "Дмитрий Соколов", "+7 (999) 777-88-99")
        {
            ImageUrl = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=400&h=400&fit=crop&crop=faces",
            Vehicle = "Велосипед",
            Rating = 4.7m,
            DeliveriesCount = 567,
            Description = "Доставляет заказы в центре города. Знает все короткие пути."
        },
        new Courier(4, "Елена Смирнова", "+7 (999) 222-33-44")
        {
            ImageUrl = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=400&h=400&fit=crop&crop=faces",
            Vehicle = "Автомобиль",
            Rating = 4.8m,
            DeliveriesCount = 1035,
            Description = "Всегда улыбается и желает приятного аппетита. Любимица постоянных клиентов."
        },
        new Courier(5, "Иван Кузнецов", "+7 (999) 555-66-77")
        {
            ImageUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?w=400&h=400&fit=crop&crop=faces",
            Vehicle = "Мотоцикл",
            Rating = 4.6m,
            DeliveriesCount = 743,
            Description = "Доставляет даже в час пик. Быстро, но безопасно."
        }
    };

    public static List<Courier> GetAll() => _couriers;

    public static Courier? GetById(int id) =>
        _couriers.FirstOrDefault(c => c.Id == id);
    public static void Add(Courier courier)
    {
        // Автоматически присваиваем новый ID через рефлексию (так как setter закрыт)
        typeof(Courier).GetProperty("Id")?.SetValue(courier, NextId());
        _couriers.Add(courier);
    }

    public static int NextId() =>
        _couriers.Any() ? _couriers.Max(c => c.Id) + 1 : 1;

    public static void Remove(Courier courier) => _couriers.Remove(courier);
}