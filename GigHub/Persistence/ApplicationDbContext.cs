﻿using GigHub.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GigHub.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>().HasRequired(a => a.Gig).WithMany(g => g.Attendances).WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Followers).WithRequired(u => u.Followee).WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>().HasMany(a => a.Followees).WithRequired(u => u.Follower).WillCascadeOnDelete(false);
            modelBuilder.Entity<UserNotification>().HasRequired(n => n.User).WithMany(u => u.UserNotifications).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}