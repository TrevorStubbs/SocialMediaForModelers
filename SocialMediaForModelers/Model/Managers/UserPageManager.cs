using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Managers
{
    public class UserPageManager //: IUserPage
    {
        private SMModelersContext _context;
        private IUserPost _posts;

        public UserPageManager(SMModelersContext context, IUserPost posts)
        {
            _context = context;
            _posts = posts;
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
                    ID = page.ID,
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
                        ID = page.ID,
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
                ID = page.ID,
                UserId = page.UserId,
                PageName = page.PageName,
                PageContent = page.PageContent
            };

            return pageDTO;
        }

        // Update

        // Delete


    }
}
