using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class EditDishModel : PageModel
{
    private readonly AppDbContext _context;
    public EditDishModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Dish Dish { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        // Загружаем блюдо
        var existingDish = await _context.Dishes.FindAsync(id);
        if (existingDish == null) return NotFound();

        Dish = existingDish;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id) // <--- ID передается сюда из URL!
    {
        if (!ModelState.IsValid) return Page();

        var dishToUpdate = await _context.Dishes.FindAsync(id);
        if (dishToUpdate == null) return NotFound();

        // Обновляем поля
        dishToUpdate.Name = Dish.Name;
        dishToUpdate.Category = Dish.Category;
        dishToUpdate.Price = Dish.Price;
        dishToUpdate.Description = Dish.Description;
        dishToUpdate.ImageUrl = Dish.ImageUrl;

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}