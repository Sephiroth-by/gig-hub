﻿using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using GigHub.Persistence;
using GigHub.Core;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig.ArtistId != User.Identity.GetUserId())
                return Unauthorized();

            if (gig.IsCancelled)
            {
                return NotFound();
            }

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
