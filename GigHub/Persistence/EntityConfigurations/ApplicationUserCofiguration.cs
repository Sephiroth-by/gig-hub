using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.EntityConfigurations
{
    public class ApplicationUserCofiguration: EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserCofiguration()
        {
            Property(a => a.Name).IsRequired().HasMaxLength(100);
            HasMany(a => a.Followers).WithRequired(u => u.Followee).WillCascadeOnDelete(false);
            HasMany(a => a.Followees).WithRequired(u => u.Follower).WillCascadeOnDelete(false);
        }
    }
}