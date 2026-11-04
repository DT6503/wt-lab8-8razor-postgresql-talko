using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_talko.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Login { get; set; } = "";

    [Required]
    [StringLength(100, MinimumLength = 4)]
    public string Password { get; set; } = "";
}