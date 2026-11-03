using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Restaurants;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public IndexModel(AppDbContext context) => _context = context;

    public List<Restaurant> Restaurants { get; set; } = new();

    public async Task OnGetAsync()
    {
        Restaurants = await _context.Restaurants.ToListAsync();
    }
}