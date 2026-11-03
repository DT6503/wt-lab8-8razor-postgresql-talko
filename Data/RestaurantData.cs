using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Data;

public static class RestaurantData
{
    private static List<Restaurant> _restaurants = new List<Restaurant>
    {
        new Restaurant(1, "Золотой Фазан", "ул. Пушкина, 10")
        {
            Description = "Изысканная европейская кухня в историческом центре",
            ImageUrl = "https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?w=600&h=400&fit=crop",
            Rating = 4.8m,
            Phone = "+7 (999) 123-45-67"
        },
        new Restaurant(2, "Императорский Двор", "пр. Ленина, 25")
        {
            Description = "Русская кухня в атмосфере дворянской усадьбы",
            ImageUrl = "https://images.unsplash.com/photo-1552566626-52f8b828add9?w=600&h=400&fit=crop",
            Rating = 4.6m,
            Phone = "+7 (999) 234-56-78"
        },
        new Restaurant(3, "Сакура", "ул. Мира, 8")
        {
            Description = "Аутентичные японские блюда от шеф-повара из Токио",
            ImageUrl = "https://images.unsplash.com/photo-1579027989536-b7b1f875659b?w=600&h=400&fit=crop",
            Rating = 4.9m,
            Phone = "+7 (999) 345-67-89"
        }
    };

    public static List<Restaurant> GetAll() => _restaurants;

    public static Restaurant? GetById(int id) =>
        _restaurants.FirstOrDefault(r => r.Id == id);

    public static void Add(Restaurant r)
    {
        typeof(Restaurant).GetProperty("Id")?.SetValue(r, NextId());
        _restaurants.Add(r);
    }

    public static int NextId() =>
        _restaurants.Any() ? _restaurants.Max(r => r.Id) + 1 : 1;

    public static void Remove(Restaurant restaurant) => _restaurants.Remove(restaurant);
}