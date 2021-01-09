using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorqqq.Model;

namespace razorqqq.Pages.CopyList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Copy> Copies { get; set; }
        public async Task  OnGet()
        {
            Copies = await _db.Copy.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var copy = await _db.Copy.FindAsync(id);
            if (copy == null)
            {
                return NotFound();
            }
            else
            {
                _db.Copy.Remove(copy);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
        }
    }
}
