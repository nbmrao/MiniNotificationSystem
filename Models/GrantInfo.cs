using System.ComponentModel.DataAnnotations;

namespace MiniNotificationSystem.Models
{
    
    public class GrantInfo
    {
        public int Id { get; set; }
        public string? GrantName { get; set; }

        public string? GrantMessage { get; set; }
    }
}
