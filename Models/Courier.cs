using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_talko.Models;

public class Courier : BaseEntity
{
    [Required(ErrorMessage = "Введите ФИО")]
    [StringLength(100)]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Введите телефон")]
    [Phone]
    public string Phone { get; set; } = "";

    public string ImageUrl { get; set; } = "";
    public string Vehicle { get; set; } = "";
    public string Description { get; set; } = "";

    [Range(0.0, 5.0, ErrorMessage = "Рейтинг от 0 до 5")]
    public decimal Rating { get; set; }

    [Range(0, 100000)]
    public int DeliveriesCount { get; set; }

    public Courier() : base() { }

    public Courier(int id, string fullName, string phone) : base(id)
    {
        FullName = fullName;
        Phone = phone;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Курьер {Id}] {FullName} | тел. {Phone} | ⭐ {Rating} | {Vehicle}");
    }
}