using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    public class NotificationApplicationUser
    {
        public int Id { get; set; }
        public Notification Notification { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
