using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;
    public DeleteModel(AppDbContext context) => _context = context;

    public Dish? Dish { get; set; }

    public IActionResult OnGet(int id)
    {
        Dish = _context.Dishes.Find(id);
        return Dish == null ? NotFound() : Page();
    }

    public IActionResult OnPost(int id)
    {
        var dish = _context.Dishes.Find(id);
        if (dish != null)
        {
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }
        return RedirectToPage("./Index");
    }
}