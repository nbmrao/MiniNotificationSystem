using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniNotificationSystem.Data;
using MiniNotificationSystem.Models;

namespace MiniNotificationSystem.Pages.Grants
{
    public class CreateModel : PageModel
    {
        private readonly MiniNotificationSystem.Data.MiniNotificationSystemContext _context;

        public CreateModel(MiniNotificationSystem.Data.MiniNotificationSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GrantInfo GrantInfo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.GrantInfo == null || GrantInfo == null)
            {
                return Page();
            }

            _context.GrantInfo.Add(GrantInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
