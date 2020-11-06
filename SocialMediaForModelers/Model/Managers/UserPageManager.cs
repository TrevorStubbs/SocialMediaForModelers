using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Entities.JoinEntites;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Managers
{
    public class UserPageManager : IUserPage
    {
        private SMModelersContext _context;
        private IUserPost _post;

        public UserPageManager(SMModelersContext context, IUserPost post)
        {
            _context = context;
            _post = post;
        }

        // Create
        public async Task<UserPageDTO> Create(UserPageDTO page)
        {
            UserPage newPage = new UserPage()
            {
                UserId = page.UserId,
                PageName = page.PageName,
                PageContent = page.PageContent
            };

            _context.Entry(newPage).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return page;
        }

        // Read All
        public async Task<List<UserPageDTO>> GetAllPages()
        {
            var pages = await _context.UserPages.ToListAsync();

            var pageList = new List<UserPageDTO>();

            foreach (var page in pages)
            {
                pageList.Add(new UserPageDTO()
                {
                    Id = page.ID,
                    UserId = page.UserId,
                    PageName = page.PageName,
                    PageContent = page.PageContent
                });
            }

            return pageList;
        }

        // Read All for a user
        public async Task<List<UserPageDTO>> GetAllPagesForAUser(string userId)
        {
            {
                var pages = await _context.UserPages.Where(x => x.UserId == userId).ToListAsync();

                var pageList = new List<UserPageDTO>();

                foreach (var page in pages)
                {
                    pageList.Add(new UserPageDTO()
                    {
                        Id = page.ID,
                        UserId = page.UserId,
                        PageName = page.PageName,
                        PageContent = page.PageContent
                    });
                }

                return pageList;
            }
        }

        // Read A post
        public async Task<UserPageDTO> GetASpecificPage(int pageId)
        {
            var page = await _context.UserPages.Where(x => x.ID == pageId).FirstOrDefaultAsync();

            var pageDTO = new UserPageDTO()
            {
                Id = page.ID,
                UserId = page.UserId,
                PageName = page.PageName,
                PageContent = page.PageContent
            };

            return pageDTO;
        }

        // Update
        public async Task<UserPageDTO> Update(UserPageDTO page, int pageId)
        {
            UserPage updatePage = new UserPage()
            {
                ID = page.Id,
                UserId = page.UserId,
                PageName = page.PageName,
                PageContent = page.PageContent
            };

            _context.Entry(updatePage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return page;
        }

        // Delete
        public async Task Delete(int pageId)
        {
            var pageToBeDeleted = await _context.UserPages.FindAsync(pageId);
            _context.Entry(pageToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // Add a like
        public async Task AddALikeToAPage(int pageId, string userId)
        {
            var newLike = new PageLike()
            {
                PageId = pageId,
                UserId = userId
            };

            _context.Entry(newLike).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        // Get likes
        public async Task<LikeDTO> GetPageLikes(int pageId, string userId)
        {
            var likes = await _context.PageLikes.Where(x => x.PageId == pageId).ToListAsync();

            LikeDTO likeDTO = new LikeDTO()
            {
                NumberOfLikes = likes.Count,
                UserLiked = UserLiked(likes, userId)
            };

            return likeDTO;
        }

        // Delete a like from a page
        public async Task DeleteALike(int pageId, string userId)
        {
            var like = await _context.PageLikes.Where(x => x.PageId == pageId && x.UserId == userId).FirstOrDefaultAsync();

            _context.Entry(like).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // Add A Post to a page
        public async Task AddAPostToAPage(int pageId, int postId)
        {
            UserPageToPost newPostJoin = new UserPageToPost()
            {
                PageId = pageId,
                PostId = postId
            };

            _context.Entry(newPostJoin).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        // Delete a post from a page
        public async Task DeleteAPostFromAPage(int pageId, int postId)
        {
            var postJoin = await _context.UserPageToPosts.Where(x => x.PageId == pageId && x.PostId == postId).FirstOrDefaultAsync();

            _context.Entry(postJoin).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        private bool UserLiked(List<PageLike> likes, string userId)
        {
            foreach (var like in likes)
            {
                if (like.UserId == userId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
