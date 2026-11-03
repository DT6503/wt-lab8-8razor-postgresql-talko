using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;
    public CreateModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Dish Dish { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        // Устанавливаем дату создания в UTC
        typeof(Dish).GetProperty("CreatedAt")?.SetValue(Dish, DateTime.UtcNow);

        _context.Dishes.Add(Dish);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}