using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorqqq.Model;

namespace razorqqq.Pages.CopyList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Copy Copy { get; set; }
        public async Task OnGet(int id)
        {
            Copy = await _db.Copy.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CopyFromDb = await _db.Copy.FindAsync(Copy.Id);
                CopyFromDb.Name = Copy.Name;
                CopyFromDb.Author = Copy.Author;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
