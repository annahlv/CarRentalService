using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models.ViewModels
{
    public class NotificationViewModel
    {
        public Notification Notification { get; set; }
        public NotificationApplicationUser UserNotification { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
        public IEnumerable<NotificationApplicationUser> UserNotifications { get; set; }
    }
}
