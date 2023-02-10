using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniNotificationSystem.Models;

namespace MiniNotificationSystem.Data
{
    public class MiniNotificationSystemContext : DbContext
    {
        public MiniNotificationSystemContext (DbContextOptions<MiniNotificationSystemContext> options)
            : base(options)
        {
        }

        public DbSet<MiniNotificationSystem.Models.GrantInfo> GrantInfo { get; set; } = default!;
    }
}
