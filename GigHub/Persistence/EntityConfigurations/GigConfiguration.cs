﻿using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHub.Persistence.EntityConfigurations
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            Property(g => g.ArtistId).IsRequired();
            Property(g => g.GenreId).IsRequired();
            Property(g => g.Venue).IsRequired().HasMaxLength(255);
            HasMany(g=>g.Attendances).WithRequired(g => g.Gig).WillCascadeOnDelete(false);
        }
    }
}