using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public bool IsCancelled { get; private set; }
        public ApplicationUser Artist { get; set; }
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.GigCanceled(this);

            foreach (var user in Attendances.Select(a => a.Attendee))
            {
                user.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, byte genre)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            DateTime = dateTime;
            Venue = venue;
            GenreId = genre; 

            foreach (var user in Attendances.Select(a => a.Attendee))
            {
                user.Notify(notification);
            }
        }
    }
}