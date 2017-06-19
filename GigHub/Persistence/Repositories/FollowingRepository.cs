using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
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

        public IEnumerable<ApplicationUser> GetUserFollowees(string userId)
        {
            return _context.Followings.Where(f => f.FollowerId == userId).Select(f => f.Followee).ToList();
        }

        public Following GetFollowing(string artistId, string userId)
        {
            return _context.Followings.SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == artistId);
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}