using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        List<UserNotification> GetUserNotifications(string userId);
        IEnumerable<Notification> GetUserNotificationsWithArtist(string userId);
    }
}