using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_talko.Models;

public class Dish : BaseEntity
{
    [Required(ErrorMessage = "Введите название")]
    [StringLength(100)]
    public string Name { get; set; } = "";

    [Range(0.01, 100000, ErrorMessage = "Цена должна быть положительной")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Введите категорию")]
    public string Category { get; set; } = "";

    public string Description { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public bool IsAvailable { get; set; }

    public Dish(int id, string name, decimal price, string category) : base(id)
    {
        Name = name;
        Category = category;
        UpdatePrice(price);
    }
    public Dish() : base()
    {
    }


    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice > 0) Price = newPrice;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Блюдо {Id}]: {Name} | {Category} | {Price} руб.");
    }
}