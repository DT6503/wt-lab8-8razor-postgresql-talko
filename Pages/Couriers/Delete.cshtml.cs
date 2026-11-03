using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Couriers;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;
    public DeleteModel(AppDbContext context) => _context = context;

    public Courier? Courier { get; set; }

    public IActionResult OnGet(int id)
    {
        Courier = _context.Couriers.Find(id);
        return Courier == null ? NotFound() : Page();
    }

    public IActionResult OnPost(int id)
    {
        var courier = _context.Couriers.Find(id);
        if (courier != null)
        {
            _context.Couriers.Remove(courier);
            _context.SaveChanges();
        }
        return RedirectToPage("./Index");
    }
}