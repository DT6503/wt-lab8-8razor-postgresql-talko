using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_talko.Models;

public class Restaurant : BaseEntity
{
    [Required(ErrorMessage = "Введите название ресторана")]
    [StringLength(100)]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Введите адрес")]
    [StringLength(200)]
    public string Address { get; set; } = "";

    public string Description { get; set; } = "";
    public string ImageUrl { get; set; } = "";

    [Range(0.0, 5.0, ErrorMessage = "Рейтинг от 0 до 5")]
    public decimal Rating { get; set; }

    [Phone]
    public string Phone { get; set; } = "";

    public Restaurant() : base() { }

    public Restaurant(int id, string title, string address) : base(id)
    {
        Title = title;
        Address = address;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Ресторан {Id}] {Title} | {Address} | ⭐ {Rating}");
    }
}