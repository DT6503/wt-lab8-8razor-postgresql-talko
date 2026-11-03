using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public IndexModel(AppDbContext context) => _context = context;

    public List<Dish> Dishes { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Dishes.AsQueryable();
        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(d => d.Name.Contains(Search));
        }
        Dishes = await query.OrderBy(d => d.Name).ToListAsync();
    }

    // ОБРАБОТЧИК ДЛЯ СОХРАНЕНИЯ ПРЯМО ИЗ СПИСКА
    public async Task<IActionResult> OnPostUpdateAsync(int id, string name, string category, decimal price)
    {
        var dish = await _context.Dishes.FindAsync(id);
        if (dish != null)
        {
            dish.Name = name;
            dish.Category = category;
            dish.Price = price;
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("./Index");
    }
}