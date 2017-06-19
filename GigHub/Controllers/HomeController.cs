using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using GigHub.Repositories;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private FollowingRepository _followingRepository;
        private GigRepository _gigRepository;
        private AttendanceRepository _attendanceRepository;


        public HomeController()
        {
            _context = new ApplicationDbContext();
            _followingRepository = new FollowingRepository(_context);
            _gigRepository = new GigRepository(_context);
            _attendanceRepository = new AttendanceRepository(_context);
        }

        public ActionResult Index(string query = null)
        {
            var upComingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCancelled);

            if (!string.IsNullOrWhiteSpace(query))
            {
                upComingGigs = upComingGigs.Where(g => g.Artist.Name.Contains(query) ||
                                                       g.Genre.Name.Contains(query) ||
                                                       g.Venue.Contains(query));
            }

            var userId = User.Identity.GetUserId();

            var viewModel = new GigsViewModel
            {
                UpComingGigs = upComingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = _attendanceRepository.GetFutureAttendances(userId).ToLookup(a => a.GigId),
                Followings = _followingRepository.GetUserFollowings(userId).ToLookup(f => f.FolloweeId)
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}