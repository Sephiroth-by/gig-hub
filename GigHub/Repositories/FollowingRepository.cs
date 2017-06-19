using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Repositories
{
    public class FollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Following> GetUserFollowings(string userId)
        {
            return _context.Followings.Where(f => f.FollowerId == userId).ToList();
        }

        public Following GetFollowing(string artistId, string userId)
        {
            return _context.Followings.SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == artistId);
        }
    }
}