using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Orders;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;
    public CreateModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Order Order { get; set; } = new();

    public SelectList Dishes { get; set; } = default!;
    public SelectList Couriers { get; set; } = default!;

    public async Task OnGetAsync()
    {
        // Загружаем данные для выпадающих списков
        Dishes = new SelectList(await _context.Dishes.ToListAsync(), "Id", "Name");
        Couriers = new SelectList(await _context.Couriers.ToListAsync(), "Id", "FullName");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }

        // Цена берется из формы
        Order.OrderDate = DateTime.UtcNow;
        _context.Orders.Add(Order);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}