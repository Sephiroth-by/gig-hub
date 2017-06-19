using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHub.Core.Models
{
    public class UserNotification
    {
        public string UserId { get; private set; }
        public int NotificationId { get; private set; }
        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }
        public bool IsRead { get; private set; }

        public void Read()
        {
            IsRead = true;
        }

        protected UserNotification()
        {

        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }

            User = user;
            Notification = notification;
        }
    }
}