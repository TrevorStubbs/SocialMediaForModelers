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
        Task<UserPageDTO> Update(UserPageDTO page);

        // Delete A Page
        Task Delete(int pageId);
    }
}
