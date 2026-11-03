using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Restaurants;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;
    public DeleteModel(AppDbContext context) => _context = context;

    public Restaurant? Restaurant { get; set; }

    public IActionResult OnGet(int id)
    {
        Restaurant = _context.Restaurants.Find(id);
        return Restaurant == null ? NotFound() : Page();
    }

    public IActionResult OnPost(int id)
    {
        var rest = _context.Restaurants.Find(id);
        if (rest != null)
        {
            _context.Restaurants.Remove(rest);
            _context.SaveChanges();
        }
        return RedirectToPage("./Index");
    }
}