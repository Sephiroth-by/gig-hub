﻿using System;
using System.Linq;
using System.Web;

namespace GigHub.Core.DTOs
{
    public class GigDTO
    {
        public int Id { get; set; }

        public bool IsCancelled { get; set; }

        public UserDTO Artist { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDTO Genre { get; set; }
    }
}