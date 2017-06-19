using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserNotification> GetUserNotifications(string userId)
        {
           return _context.UserNotifications.Where(n => n.UserId == userId && !n.IsRead).ToList();
        }

        public IEnumerable<Notification> GetUserNotificationsWithArtist(string userId)
        {
            return _context.UserNotifications.Where(n => n.UserId == userId && !n.IsRead).Select(n => n.Notification).Include(n => n.Gig.Artist).ToList();
        }
    }
}