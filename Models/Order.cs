using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_talko.Models;

public class Order
{
    public int Id { get; set; }
    public string Address { get; set; } = "";
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "В обработке";

    // Внешние ключи
    public int DishId { get; set; }
    public int CourierId { get; set; }
}