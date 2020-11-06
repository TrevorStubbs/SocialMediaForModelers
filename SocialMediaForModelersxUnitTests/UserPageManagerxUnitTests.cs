using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using SocialMediaForModelers.Model.Managers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace SocialMediaForModelersxUnitTests
{
    public class UserPageManagerxUnitTests : TestingDatabase
    {
        private IUserPage BuildService()
        {
            return new UserPageManager(_db, _post);
        }

        [Fact]
        public async void CanCreateANewPage()
        {
            var page = UserPageTestDTO1();
            var service = BuildService();

            var saved = await service.Create(page);

            Assert.NotNull(saved);
            Assert.Equal(page.Id, saved.Id);
            Assert.Equal(page.UserId, saved.UserId);
            Assert.Equal(page.PageName, saved.PageName);
            Assert.Equal(page.PageContent, saved.PageContent);
        }

        [Fact]
        public async void CanGetAllPages()
        {
            var page1 = UserPageTestDTO1();
            var page2 = UserPageTestDTO2();

            var service = BuildService();

            var expectedList = new List<string>();

            expectedList.Add("Seed Page");
            expectedList.Add(page1.PageName);
            expectedList.Add(page2.PageName);

            await service.Create(page1);
            await service.Create(page2);

            var returnFromMethod = await service.GetAllPages();

            var returnList = new List<string>();

            foreach (var page in returnFromMethod)
            {
                returnList.Add(page.PageName);
            }

            Assert.NotNull(returnFromMethod);
            Assert.NotNull(returnList);
            Assert.Equal(expectedList, returnList);
        }

        [Fact]
        public async void CanGetAllPagesForAUser()
        {
            var post1 = UserPageTestDTO1();
            var post2 = UserPageTestDTO2();
            var post3 = UserPageTestDTO3();
            var post4 = UserPageTestDTO4();

            var service = BuildService();

            var expecteList = new List<string>();
            expecteList.Add("1234");
            expecteList.Add(post1.UserId);
            expecteList.Add(post2.UserId);

            await service.Create(post1);
            await service.Create(post2);
            await service.Create(post3);
            await service.Create(post4);

            var returnFromMethod = await service.GetAllPagesForAUser("1234");

            var returnList = new List<string>();

            foreach (var page in returnFromMethod)
            {
                returnList.Add(page.UserId);
            }

            Assert.NotNull(returnFromMethod);
            Assert.NotNull(returnList);
            Assert.Equal(expecteList, returnList);
        }

        [Fact]
        public async void CanGetASpecificPage()
        {
            var service = BuildService();
            var expectedId = 1;
            var expectedUserId = "1234";
            var expectedPageName = "Seed Page";

            var returnFromMethod = await service.GetASpecificPage(1);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedId, returnFromMethod.Id);
            Assert.Equal(expectedUserId, returnFromMethod.UserId);
            Assert.Equal(expectedPageName, returnFromMethod.PageName);
        }

        [Fact]
        public async void CanUpdateAPage()
        {
            var service = BuildService();

            var updatedPage = new UserPageDTO()
            {
                Id = 1,
                UserId = "1234",
                PageName = "UpdatedName",
                PageContent = "UpdatedContent"
            };

            var returnFromMethod = await service.Update(updatedPage, 1);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(updatedPage.PageName, returnFromMethod.PageName);
            Assert.Equal(updatedPage.PageContent, returnFromMethod.PageContent);
        }

        [Fact]
        public async void CanDeleteAPage()
        {
            var service = BuildService();
            await service.Create(UserPageTestDTO1());
            await service.Create(UserPageTestDTO2());

            var expectedList = new List<int>()
            {
                2,3
            };

            await service.Delete(1);

            var returnFromMethod = await service.GetAllPages();

            var returnList = new List<int>();

            foreach (var page in returnFromMethod)
            {
                returnList.Add(page.Id);
            }

            Assert.NotNull(returnFromMethod);
            Assert.NotNull(returnList);
            Assert.Equal(expectedList, returnList);
        }

        // ================== TODO: Future Tests ==============
        // Test adding likes
        // Test retrieving like info
        // Test Deleting a like
        // Test Adding a post to a page
        // Test Deleting a post from a page
        // =======================================================

        private UserPageDTO UserPageTestDTO1()
        {
            var userId = "1234";

            var page = new UserPageDTO()
            {
                Id = 2,
                UserId = userId,
                PageName = "Page Name 1",
                PageContent = "Page Content 1"
            };

            return page;
        }

        private UserPageDTO UserPageTestDTO2()
        {
            var userId = "1234";

            var page = new UserPageDTO()
            {
                Id = 3,
                UserId = userId,
                PageName = "Page Name 2",
                PageContent = "Page Content 2"
            };

            return page;
        }

        private UserPageDTO UserPageTestDTO3()
        {
            var userId = "5678";

            var page = new UserPageDTO()
            {
                Id = 4,
                UserId = userId,
                PageName = "Page Name 3",
                PageContent = "Page Content 3"
            };

            return page;
        }
        private UserPageDTO UserPageTestDTO4()
        {
            var userId = "5678";

            var page = new UserPageDTO()
            {
                Id = 5,
                UserId = userId,
                PageName = "Page Name 5",
                PageContent = "Page Content 5"
            };

            return page;
        }

    }
}
