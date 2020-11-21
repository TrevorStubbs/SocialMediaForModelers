using SocialMediaForModelers.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface IUserPage
    {
        // Create
        /// <summary>
        /// Creates a new UserPage entity.
        /// </summary>
        /// <param name="page">The UserPageDTO to create the new entity (don't include a value for the Id key)</param>
        /// <returns>The provided UserPageDTO</returns>
        Task<UserPageDTO> Create(UserPageDTO page);

        // Read All Pages
        /// <summary>
        /// Gets all of the pages in the application from the database
        /// </summary>
        /// <returns>A list of UserPageDTOs</returns>
        Task<List<UserPageDTO>> GetAllPages();

        // Read All User's Pages
        /// <summary>
        /// Gets all UserPages owned by a specific user from the database
        /// </summary>
        /// <param name="userId">The User's database Id</param>
        /// <returns>A list of UserPageDTOs</returns>
        Task<List<UserPageDTO>> GetAllPagesForAUser(string userId);

        // Read A Specific Page
        /// <summary>
        /// Gets the UserPageDTO of a specific page from the database.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <returns>A single UserPageDTO</returns>
        Task<UserPageDTO> GetASpecificPage(int pageId);

        // Update Page
        /// <summary>
        /// Update's a UserPage in the database.
        /// </summary>
        /// <param name="page">The UserPageDTO to make the update</param>
        /// <param name="pageId">The Page's database Id</param>
        /// <returns>The UserPageDTO that was provided</returns>
        Task<UserPageDTO> Update(UserPageDTO page, int pageId);

        // Delete A Page
        /// <summary>
        /// Delete a UserPage from the database.
        /// </summary>
        /// <param name="pageId">The page's database Id</param>
        /// <returns>Void</returns>
        Task Delete(int pageId);

        // Add like
        /// <summary>
        /// Add a like to the page.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <param name="userId">The user's database id.</param>
        /// <returns>Void</returns>
        Task AddALikeToAPage(int pageId, string userId);

        // Get likes
        /// <summary>
        /// Gets like data for a UserPage
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="userId">The user's database id</param>
        /// <returns>A LikeDTO object</returns>
        Task<LikeDTO> GetPageLikes(int pageId, string userId);

        // Delete likes
        /// <summary>
        /// Deletes a like from a page.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="userId">The user's database id</param>
        /// <returns>Void</returns>
        Task DeleteALike(int postId, string userId);

        // Add a post to a page.
        /// <summary>
        /// Adds a UserPost to a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="postId">The post's database id</param>
        /// <returns>Void</returns>
        Task AddAPostToAPage(int pageId, int postId);

        // Delete a post from a page.
        /// <summary>
        /// Deletes a UserPost from a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id</param>
        /// <param name="postId">The post's database id</param>
        /// <returns>Void</returns>
        Task DeleteAPostFromAPage(int pageId, int postId);
    }
}
