using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using SocialMediaForModelers.Model.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialMediaForModelersxUnitTests
{
    public class PostCommentManagerTests : TestingDatabase
    {
        private IPostComment BuildService()
        {
            return new PostCommentManager(_db);
        }

        [Fact]
        public async void CanCreateANewComment()
        {
            var comment = TestDto1();

            var service = BuildService();

            var saved = await service.Create(comment, comment.UserId);

            Assert.NotNull(saved);
            Assert.Equal(comment.Id, saved.Id);
            Assert.Equal(comment.UserId, saved.UserId);
            Assert.Equal(comment.Body, saved.Body);
        }

        [Fact]
        public async void CanGetAllUsersComments()
        {
            var comment1 = TestDto1();
            var comment2 = TestDto2();

            var service = BuildService();

            var expectedList = new List<string>();
            var firstComment = await service.GetASpecificComment(1);
            expectedList.Add(firstComment.Body);
            expectedList.Add(comment1.Body);
            expectedList.Add(comment2.Body);

            
            await service.Create(comment1, comment1.UserId);
            await service.Create(comment2, comment2.UserId);         

            var returnFromMethod = await service.GetAllUsersComments(comment1.UserId);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Body);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedList, returnList);
        }

        [Fact]
        public async void CanGetASpecificComment()
        {
            var service = BuildService();
            var comment = await service.Create(TestDto1(), TestDto1().UserId);

            var returnFromMethod = await service.GetASpecificComment(comment.Id);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(TestDto1().Body, returnFromMethod.Body);
            Assert.Equal(TestDto1().Id, returnFromMethod.Id);
            Assert.Equal(TestDto1().UserId, returnFromMethod.UserId);
        }

        [Fact]
        public async void CanUpdateAComment()
        {
            var service = BuildService();

            var updatedComment = new PostCommentDTO()
            {
                Id = 1,
                UserId = "1234",
                Body = "I am updated"
            };

            var returnFromMethod = await service.Update(updatedComment);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(updatedComment.Body, returnFromMethod.Body);
        }

        [Fact]
        public async void CanDeleteAComment()
        {
            var service = BuildService();
            await service.Create(TestDto1(), TestDto1().UserId);
            await service.Create(TestDto2(), TestDto2().UserId);

            await service.Delete(1);
            var returnFromMethod = await service.GetAllUsersComments("1234");

            var expected = new List<string>()
            {
                "I am comment number 1", "I am a comment number 2"
            };

            var returnList = new List<string>();
            

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Body);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnList);
        }

        // ================= TODO: Test Likes!!! ========================



        public PostCommentDTO TestDto1()
        {
            var userId = "1234";

            var dto = new PostCommentDTO()
            {
                Id = 2,
                UserId = userId,
                Body = "I am comment number 1"
            };

            return dto;
        }

        public PostCommentDTO TestDto2()
        {
            var userId = "1234";

            var dto = new PostCommentDTO()
            {
                Id = 3,
                UserId = userId,
                Body = "I am a comment number 2"
            };

            return dto;
        }
        public PostCommentDTO TestDto3()
        {
            var userId = "5678";

            var dto = new PostCommentDTO()
            {
                Id = 4,
                UserId = userId,
                Body = "I am a comment number 3"
            };

            return dto;
        }
        public PostCommentDTO TestDto4()
        {
            var userId = "5678";

            var dto = new PostCommentDTO()
            {
                Id = 5,
                UserId = userId,
                Body = "I am a comment number 4"
            };

            return dto;
        }
    }
}
