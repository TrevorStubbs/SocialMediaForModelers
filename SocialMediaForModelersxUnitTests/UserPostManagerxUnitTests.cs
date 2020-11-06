/*
 * ============= TODO: Engineer a fix for these tests ==========================
 */

//using SocialMediaForModelers.Model.DTOs;
//using SocialMediaForModelers.Model.Interfaces;
//using SocialMediaForModelers.Model.Managers;
//using SQLitePCL;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace SocialMediaForModelersxUnitTests
//{
//    public class UserPostManagerxUnitTests : TestingDatabase
//    {
//        private IUserPost BuildService()
//        {
//            return new UserPostManager(_db, _comment, _image);
//        }

//        [Fact]
//        public async void CanCreateANewPost()
//        {
//            var post = UserPostTestDTO1();
//            var service = BuildService();

//            var saved = await service.Create(post);

//            Assert.NotNull(saved);
//            Assert.Equal(post.Id, saved.Id);
//            Assert.Equal(post.UserId, saved.UserId);
//            Assert.Equal(post.Caption, saved.Caption);
//        }

//        [Fact]
//        public async void CanGetAllPosts()
//        {
//            var post1 = UserPostTestDTO1();
//            var post2 = UserPostTestDTO2();

//            var service = BuildService();

//            var expectedList = new List<string>();
//            // var firstPost = await service.GetASpecificPost(1);
//            expectedList.Add("This is my post");
//            expectedList.Add(post1.Caption);
//            expectedList.Add(post2.Caption);

//            await service.Create(post1);
//            await service.Create(post2);

//            var returnFromMethod = await service.GetAllPosts();

//            var returnList = new List<string>();

//            foreach (var post in returnFromMethod)
//            {
//                returnList.Add(post.Caption);
//            }

//            Assert.NotNull(returnFromMethod);
//            Assert.Equal(expectedList, returnList);
//        }

//        [Fact]
//        public async void CanGetAllPostsForAUser()
//        {
//            var post1 = UserPostTestDTO1();
//            var post2 = UserPostTestDTO2();

//            var service = BuildService();

//            var expectedList = new List<string>();
//            expectedList.Add("This is my post");
//            expectedList.Add(post1.Caption);
//            expectedList.Add(post2.Caption);

//            await service.Create(post1);
//            await service.Create(post2);

//            var returnFromMethod = await service.GetAllUserPosts("1234");

//            var returnList = new List<string>();

//            foreach (var post in returnFromMethod)
//            {
//                returnList.Add(post.Caption);
//            }

//            Assert.NotNull(returnFromMethod);
//            Assert.Equal(expectedList, returnList);
//        }

//        [Fact]
//        public async void CanGetASpecificPost()
//        {
//            var service = BuildService();
//            var expectedId = 1;
//            var expectedUserId = "1234";
//            var expectedCaption = "This is my post";

//            var returnFromMethod = await service.GetASpecificPost(1);

//            Assert.NotNull(returnFromMethod);
//            Assert.Equal(expectedId, returnFromMethod.Id);
//            Assert.Equal(expectedUserId, returnFromMethod.UserId);
//            Assert.Equal(expectedCaption, returnFromMethod.Caption);
//        }

//        [Fact]
//        public async void CanUpdateAPost()
//        {
//            var service = BuildService();

//            var updatedPost = new UserPostDTO()
//            {
//                Id = 1,
//                UserId = "1234",
//                Caption = "I am an updated post"
//            };

//            var returnFromMethod = await service.Update(updatedPost);

//            Assert.NotNull(updatedPost);
//            Assert.Equal(updatedPost.Caption, returnFromMethod.Caption);
//        }

//        [Fact]
//        public async void CanDeleteAPost()
//        {
//            var service = BuildService();
//            await service.Create(UserPostTestDTO1());
//            await service.Create(UserPostTestDTO2());

//            var expectedList = new List<int>()
//            {
//                2,3
//            };

//            await service.Delete(1);

//            var returnFromMethod = await service.GetAllPosts();

//            var returnList = new List<int>();

//            foreach (var post in returnFromMethod)
//            {
//                returnList.Add(post.Id);
//            }

//            Assert.NotNull(returnList);
//            Assert.Equal(expectedList, returnList);
//        }

//        // ================ TODO: Future Tests ========================
//        // Test the Adding likes
//        // Test Retrieving like info
//        // Test Deleting a like
//        // Test Adding an image to the post
//        // Test Deleting an image from a post
//        // Test Adding a comment to a post
//        // Test Deleting a comment from a post
//        // ========================================================


//        private UserPostDTO UserPostTestDTO1()
//        {
//            var userId = "1234";

//            var post = new UserPostDTO()
//            {
//                Id = 2,
//                UserId = userId,
//                Caption = "Test DTO 1"
//            };

//            return post;
//        }

//        private UserPostDTO UserPostTestDTO2()
//        {
//            var userId = "1234";

//            var post = new UserPostDTO()
//            {
//                Id = 3,
//                UserId = userId,
//                Caption = "Test DTO 2"
//            };

//            return post;
//        }

//        private UserPostDTO UserPostTestDTO3()
//        {
//            var userId = "5678";

//            var post = new UserPostDTO()
//            {
//                Id = 4,
//                UserId = userId,
//                Caption = "Test DTO 3"
//            };

//            return post;
//        }

//        private UserPostDTO UserPostTestDTO4()
//        {
//            var userId = "5678";

//            var post = new UserPostDTO()
//            {
//                Id = 5,
//                UserId = userId,
//                Caption = "Test DTO 4"
//            };

//            return post;
//        }
//    }
//}
