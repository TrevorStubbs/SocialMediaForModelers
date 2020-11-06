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
        Task<UserPageDTO> Create(UserPageDTO page);

        // Read All Pages
        Task<List<UserPageDTO>> GetAllPages();

        // Read All User's Pages
        Task<List<UserPageDTO>> GetAllPagesForAUser(string userId);

        // Read A Specific Page
        Task<UserPageDTO> GetASpecificPage(int pageId);

        // Update Page
        Task<UserPageDTO> Update(UserPageDTO page, int pageId);

        // Delete A Page
        Task Delete(int pageId);

        // Add like
        Task AddALikeToAPage(int pageId, string userId);

        // Get likes
        Task<LikeDTO> GetPageLikes(int pageId, string userId);

        // Delete likes
        Task DeleteALike(int postId, string userId);

        // Add a post to a page.
        Task AddAPostToAPage(int pageId, int postId);

        // Delete a post from a page.
        Task DeleteAPostFromAPage(int pageId, int postId);
    }
}
