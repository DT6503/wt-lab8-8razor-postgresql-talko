using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;
    public DetailsModel(AppDbContext context) => _context = context;

    public Dish? Dish { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        Dish = await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);

        if (Dish == null) return NotFound();

        return Page();
    }
}