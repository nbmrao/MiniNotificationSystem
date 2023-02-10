using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniNotificationSystem.Data;
using MiniNotificationSystem.Models;

namespace MiniNotificationSystem.Pages.Grants
{
    public class DetailsModel : PageModel
    {
        private readonly MiniNotificationSystem.Data.MiniNotificationSystemContext _context;

        public DetailsModel(MiniNotificationSystem.Data.MiniNotificationSystemContext context)
        {
            _context = context;
        }

      public GrantInfo GrantInfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GrantInfo == null)
            {
                return NotFound();
            }

            var grantinfo = await _context.GrantInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (grantinfo == null)
            {
                return NotFound();
            }
            else 
            {
                GrantInfo = grantinfo;
            }
            return Page();
        }
    }
}
