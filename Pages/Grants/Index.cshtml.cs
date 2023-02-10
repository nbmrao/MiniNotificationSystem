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
    public class IndexModel : PageModel
    {
        private readonly MiniNotificationSystem.Data.MiniNotificationSystemContext _context;

        public IndexModel(MiniNotificationSystem.Data.MiniNotificationSystemContext context)
        {
            _context = context;
        }

        public IList<GrantInfo> GrantInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GrantInfo != null)
            {
                GrantInfo = await _context.GrantInfo.ToListAsync();
            }
        }
    }
}
