using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using GigHub.Core.ViewModels;
using Microsoft.AspNet.Identity;
using GigHub.Persistence;
using GigHub.Persistence.Repositories;
using GigHub.Core;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            var upComingGigs = _unitOfWork.Gigs.GetUpcomingGigs(query);

            var userId = User.Identity.GetUserId();

            var viewModel = new GigsViewModel
            {
                UpComingGigs = upComingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(userId).ToLookup(a => a.GigId),
                Followings = _unitOfWork.Followings.GetUserFollowings(userId).ToLookup(f => f.FolloweeId)
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