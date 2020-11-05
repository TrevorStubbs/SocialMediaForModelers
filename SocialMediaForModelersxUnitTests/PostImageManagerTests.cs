using Microsoft.AspNetCore.Mvc.ViewComponents;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using SocialMediaForModelers.Model.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SocialMediaForModelersxUnitTests
{
    public class PostImageManagerTests : TestingDatabase
    {
        private IPostImage BuildService()
        {
            return new PostImageManager(_db, _cloudImage);
        }

        [Fact]
        public async void CanCreateANewImage()
        {
            var image = TestImageDTO1();

            var service = BuildService();

            var saved = await service.Create(image, image.UserId);

            Assert.NotNull(saved);
            Assert.Equal(image.Id, saved.Id);
            Assert.Equal(image.UserId, saved.UserId);
            Assert.Equal(image.ImageURI, saved.ImageURI);
        }

        [Fact]
        public async void CanGetAllImages()
        {
            var orgImages = new List<PostImageDTO>();
            orgImages.Add(TestImageDTO1());
            orgImages.Add(TestImageDTO2());
            orgImages.Add(TestImageDTO3());
            orgImages.Add(TestImageDTO4());

            var service = BuildService();

            foreach (var item in orgImages)
            {
                await service.Create(item, item.UserId);
            }

            var returnFromMethod = await service.GetAllImages();

            Assert.NotNull(returnFromMethod);
            Assert.Equal(orgImages[0].ImageURI, returnFromMethod[1].ImageURI);
            Assert.Equal(orgImages[0].UserId, returnFromMethod[1].UserId);
            Assert.Equal(orgImages[0].Id, returnFromMethod[1].Id);
        }

        [Fact]
        public async void CanGetAllOfAUsersImages()
        {
            var orgImages = new List<PostImageDTO>();
            orgImages.Add(TestImageDTO1());
            orgImages.Add(TestImageDTO2());
            orgImages.Add(TestImageDTO3());
            orgImages.Add(TestImageDTO4());

            var service = BuildService();

            foreach (var item in orgImages)
            {
                await service.Create(item, item.UserId);
            }

            var expectedList = new List<string>();
            var firstImage = await service.GetASpecificImage(1);
            expectedList.Add(firstImage.ImageURI);
            foreach (var item in orgImages)
            {
                if(item.UserId == "1234")
                    expectedList.Add(item.ImageURI);
            }

            var returnFromMethod = await service.GetAllUsersImages("1234");

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.ImageURI);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedList, returnList);
        }

        [Fact]
        public async void CanGetASpecificImage()
        {
            var service = BuildService();

            var returnFromMethod = await service.GetASpecificImage(1);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(1, returnFromMethod.Id);
            Assert.Equal("1234", returnFromMethod.UserId);
            Assert.Equal("/Dog.png", returnFromMethod.ImageURI);
        }

        [Fact]
        public async void CanUpdateAnImage()
        {
            var service = BuildService();

            var updatedImage = new PostImageDTO()
            {
                Id = 1,
                UserId = "1234",
                ImageURI = "/Cat.png"
            };

            var returnFromMethod = await service.Update(updatedImage);
            var confirmedDBUpdated = await service.GetASpecificImage(1);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(updatedImage.ImageURI, returnFromMethod.ImageURI);
            Assert.Equal(updatedImage.ImageURI, confirmedDBUpdated.ImageURI);
        }

        [Fact]
        public async void CanDeleteAnImage()
        {
            var service = BuildService();
            await service.Create(TestImageDTO1(), TestImageDTO1().UserId);
            await service.Create(TestImageDTO2(), TestImageDTO2().UserId);

            await service.Delete(1);

            var returnFromMethod = await service.GetAllImages();

            var expected = new List<int>()
            {
                2,3
            };

            var returnList = new List<int>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Id);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnList);
        }

        private PostImageDTO TestImageDTO1()
        {
            var userId = "1234";

            var image = new PostImageDTO()
            {
                Id = 2,
                UserId = userId,
                ImageURI = "/test1.png"
            };

            return image;
        }

        private PostImageDTO TestImageDTO2()
        {
            var userId = "1234";

            var image = new PostImageDTO()
            {
                Id = 3,
                UserId = userId,
                ImageURI = "/test2.png"
            };

            return image;
        }

        private PostImageDTO TestImageDTO3()
        {
            var userId = "5678";

            var image = new PostImageDTO()
            {
                Id = 4,
                UserId = userId,
                ImageURI = "/test3.png"
            };

            return image;
        }

        private PostImageDTO TestImageDTO4()
        {
            var userId = "5678";

            var image = new PostImageDTO()
            {
                Id = 5,
                UserId = userId,
                ImageURI = "/test4.png"
            };

            return image;
        }
    }
}
