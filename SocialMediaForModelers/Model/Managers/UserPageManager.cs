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
        /// <summary>
        /// Creates a new UserPage entity.
        /// </summary>
        /// <param name="page">The UserPageDTO to create the new entity (don't include a value for the Id key)</param>
        /// <returns>The provided UserPageDTO</returns>
        public async Task<UserPageDTO> Create(UserPageDTO page)
        {
            var timeNow = DateTime.UtcNow;

            UserPage newPage = new UserPage()
            {
                UserId = page.UserId,
                PageName = page.PageName,
                PageContent = page.PageContent,
                Created = timeNow,
                Modified = timeNow
            };

            _context.Entry(newPage).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return page;
        }

        // Read All
        /// <summary>
        /// Gets all of the pages in the application from the database
        /// </summary>
        /// <returns>A list of UserPageDTOs</returns>
        public async Task<List<UserPageDTO>> GetAllPages()
        {
            var pages = await _context.UserPages.ToListAsync();

            return await FillUserPageDTOs(pages);
        }

        // Read All for a user
        /// <summary>
        /// Gets all UserPages owned by a specific user from the database
        /// </summary>
        /// <param name="userId">The User's database Id</param>
        /// <returns>A list of UserPageDTOs</returns>
        public async Task<List<UserPageDTO>> GetAllPagesForAUser(string userId)
        {
            var pages = await _context.UserPages.Where(x => x.UserId == userId).ToListAsync();

            return await FillUserPageDTOs(pages);
        }

        // Read A page
        /// <summary>
        /// Gets the UserPageDTO of a specific page from the database.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <returns>A single UserPageDTO</returns>
        public async Task<UserPageDTO> GetASpecificPage(int pageId)
        {
            var page = await _context.UserPages.Where(x => x.ID == pageId).FirstOrDefaultAsync();

            var pageDTO = new UserPageDTO()
            {
                Id = page.ID,
                UserId = page.UserId,
                PageName = page.PageName,
                PageContent = page.PageContent,
                Created = page.Created,
                Modified = page.Modified,
                PageLikes = await GetPageLikes(pageId, page.UserId)
            };

            return pageDTO;
        }

        // Update
        /// <summary>
        /// Update's a UserPage in the database.
        /// </summary>
        /// <param name="page">The UserPageDTO to make the update</param>
        /// <param name="pageId">The Page's database Id</param>
        /// <returns>The UserPageDTO that was provided</returns>
        public async Task<UserPageDTO> Update(UserPageDTO userPage, int pageId)
        {
            var databasePage = await _context.UserPages.Where(x => x.ID == pageId).FirstOrDefaultAsync();

            if (databasePage != null)
            {
                databasePage.ID = databasePage.ID;
                databasePage.UserId = userPage.UserId == null ? databasePage.UserId : userPage.UserId;
                databasePage.PageName = userPage.PageName == null ? databasePage.PageName : userPage.PageName;
                databasePage.PageContent = userPage.PageContent == null ? databasePage.PageContent : userPage.PageContent;
                databasePage.Modified = DateTime.UtcNow;
                _context.Entry(databasePage).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return await GetASpecificPage(pageId);
            }

            throw new Exception("That page does not exist.");
        }

        // Delete
        /// <summary>
        /// Delete a UserPage and all data associated with that UserPage from the database.
        /// </summary>
        /// <param name="pageId">The page's database Id</param>
        /// <returns>Void</returns>
        public async Task Delete(int pageId)
        {
            var posts = await _context.UserPageToPosts.Where(x => x.PageId == pageId).ToListAsync();

            foreach (var post in posts)
            {
                await _post.Delete(post.PostId);
            }

            await DeleteAllLikes(pageId);

            var pageToBeDeleted = await _context.UserPages.FindAsync(pageId);
            _context.Entry(pageToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // Add a like
        /// <summary>
        /// Add a like to the page.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <param name="userId">The user's database id.</param>
        /// <returns>Void</returns>
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
        /// <summary>
        /// Gets like data for a UserPage
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="userId">The user's database id</param>
        /// <returns>A LikeDTO object</returns>
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
        /// <summary>
        /// Deletes a like from a page.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="userId">The user's database id</param>
        /// <returns>Void</returns>
        public async Task DeleteALike(int pageId, string userId)
        {
            var like = await _context.PageLikes.Where(x => x.PageId == pageId && x.UserId == userId).FirstOrDefaultAsync();

            _context.Entry(like).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // Add A Post to a page
        /// <summary>
        /// Adds a UserPost to a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="postId">The post's database id</param>
        /// <returns>Void</returns>
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
        /// <summary>
        /// Deletes a UserPost from a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="postId">The post's database id</param>
        /// <returns>Void</returns>
        public async Task DeleteAPostFromAPage(int pageId, int postId)
        {
            var postJoin = await _context.UserPageToPosts.Where(x => x.PageId == pageId && x.PostId == postId).FirstOrDefaultAsync();

            _context.Entry(postJoin).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Helper method that fills UserPageDTOs
        /// </summary>
        /// <param name="inputList">A list of UserPages</param>
        /// <returns>A list of UserPageDTOs</returns>
        private async Task<List<UserPageDTO>> FillUserPageDTOs(List<UserPage> inputList)
        {
            var pageList = new List<UserPageDTO>();

            foreach (var page in inputList)
            {
                pageList.Add(new UserPageDTO()
                {
                    Id = page.ID,
                    UserId = page.UserId,
                    PageName = page.PageName,
                    PageContent = page.PageContent,
                    Created = page.Created,
                    Modified = page.Modified,
                    PageLikes = await GetPageLikes(page.ID, page.UserId)
                });
            }

            return pageList;
        }

        /// <summary>
        /// A helper method that checks to see if the user has like the page.
        /// </summary>
        /// <param name="likes">Reference to all the like from the page</param>
        /// <param name="userId">The user's database id</param>
        /// <returns>Returns 'true' if the user has liked the page</returns>
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

        /// <summary>
        /// Helper method that deletes all the likes from this page.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <returns>Void</returns>
        private async Task DeleteAllLikes(int pageId)
        {
            var likes = await _context.PageLikes.Where(x => x.PageId == pageId).ToListAsync();

            foreach (var like in likes)
            {
                _context.Entry(like).State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();
        }        
    }
}
