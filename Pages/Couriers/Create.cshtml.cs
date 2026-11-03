using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Couriers;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;
    public CreateModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Courier Courier { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Couriers.Add(Courier);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}