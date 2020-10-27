using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiplomProject.Models;
using NUglify.Helpers;

namespace DiplomProject.Models
{
    public class EFNotificationRepository : INotificationRepository
    {
        private ApplicationDbContext context;

        public EFNotificationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public void Create(Notification notification)
        {
            context.Notifications.Add(notification);
            context.SaveChanges();

            //TODO: Assign notification to users
            //var watchlists = _watchlistRepository.GetWatchlistFromPetId(petId);
            //foreach (var watchlist in watchlists)
            //{
            //    var userNotification = new NotificationApplicationUser();
            //    userNotification.UserId = watchlist.UserId;
            //    userNotification.Id = notification.Id;

            //    context.UserNotifications.Add(userNotification);
            //    context.SaveChanges();
            //}



            //_hubContext.Clients.All.InvokeAsync("displayNotification", "");
        }
        public void Assign(Notification notification, string userId)
        {
            var userNotification = new NotificationApplicationUser();
            context.UserNotifications.Add(userNotification);
            userNotification.UserId = userId;
            userNotification.Notification = notification;
            userNotification.IsRead = false;
            context.SaveChanges();
        }
        public List<NotificationApplicationUser> GetUserNotifications(string userId)
        {
            return context.UserNotifications.Where(u => u.UserId.Equals(userId) && !u.IsRead)
                                            .Include(n => n.Notification)
                                            .ToList();
        }
        public List<NotificationApplicationUser> GetAdminNotifications()
        {
            return context.UserNotifications.Where(u => u.UserId.Equals(null) && !u.IsRead)
                                            .Include(n => n.Notification)
                                            .ToList();
        }
        public List<Notification> GetAllNotifications()
        {
            return context.Notifications.ToList();
        }
        public void ReadNotification(int notificationId, string userId)
        {
            var notification = context.UserNotifications
                                        .FirstOrDefault(n => n.UserId.Equals(userId)
                                        && n.Id == notificationId);
            notification.IsRead = true;
            context.UserNotifications.Update(notification);
            context.SaveChanges();
        }
    }
}
