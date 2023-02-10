using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniNotificationSystem.Data;
using MiniNotificationSystem.Models;

namespace MiniNotificationSystem.Pages.Grants
{
    public class EditModel : PageModel
    {
        private readonly MiniNotificationSystem.Data.MiniNotificationSystemContext _context;

        public EditModel(MiniNotificationSystem.Data.MiniNotificationSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GrantInfo GrantInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GrantInfo == null)
            {
                return NotFound();
            }

            var grantinfo =  await _context.GrantInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (grantinfo == null)
            {
                return NotFound();
            }
            GrantInfo = grantinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GrantInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrantInfoExists(GrantInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GrantInfoExists(int id)
        {
          return (_context.GrantInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
