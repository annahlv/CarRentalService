using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    public interface INotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        List<NotificationApplicationUser> GetAdminNotifications();
        List<Notification> GetAllNotifications();
        void Create(Notification notification);
        void Assign(Notification notification, string userId);
        void ReadNotification(int notificationId, string userId);
    }
}
