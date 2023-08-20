using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = _context.Categories.Find(id);
                return Page();
            }
            return NotFound();
        }


        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Categories == null || Category == null)
            {
                return Page();
            }

            _context.Categories.Update(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
