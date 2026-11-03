using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Data;

public static class DishData
{
    private static List<Dish> _dishes = new List<Dish>
    {
        new Dish(1, "Пицца Маргарита", 450m, "Пицца")
        {
            Description = "Томаты, моцарелла, базилик",
            ImageUrl = "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=400&h=300&fit=crop",
            IsAvailable = true
        },
        new Dish(2, "Суши Филадельфия", 599m, "Суши")
        {
            Description = "Лосось, сыр, огурец",
            ImageUrl = "https://images.unsplash.com/photo-1579584425555-c3ce17fd4351?w=400&h=300&fit=crop",
            IsAvailable = true
        },
        new Dish(3, "Борщ украинский", 299m, "Супы")
        {
            Description = "Свёкла, капуста, мясо",
            ImageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd?w=400&h=300&fit=crop",
            IsAvailable = false
        },
        new Dish(4, "Паста Карбонара", 700m, "Паста")
        {
            Description = "Спагетти, бекон, сливки",
            ImageUrl = "https://images.unsplash.com/photo-1621996346565-e3dbc646d9a9?w=400&h=300&fit=crop",
            IsAvailable = true
        },
        new Dish(5, "Цезарь с курицей", 380m, "Салаты")
        {
            Description = "Курица, романо, пармезан",
            ImageUrl = "https://images.unsplash.com/photo-1550304943-4f24f54ddde9?w=400&h=300&fit=crop",
            IsAvailable = true
        }
    };

    public static List<Dish> GetDishes() => _dishes;

    public static Dish? GetById(int id) =>
        _dishes.FirstOrDefault(d => d.Id == id);

    public static void Add(Dish dish) => _dishes.Add(dish);

    public static bool Remove(int id)
    {
        var dish = GetById(id);
        if (dish == null) return false;
        _dishes.Remove(dish);
        return true;
    }

    public static int NextId() =>
        _dishes.Any() ? _dishes.Max(d => d.Id) + 1 : 1;
}