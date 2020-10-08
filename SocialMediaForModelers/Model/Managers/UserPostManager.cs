using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Entities.JoinEntites;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Managers
{
    public class UserPostManager //: IUserPost
    {
        private SMModelersContext _context;
        private IPostComment _postComment;
        private IPostImage _postImage;

        public UserPostManager(SMModelersContext context, IPostComment postComment, IPostImage postImage)
        {
            _context = context;
            _postComment = postComment;
            _postImage = postImage;
        }

        public async Task<UserPostDTO> Create(UserPostDTO post)
        {
            var newPost = new UserPost()
            {
                Caption = post.Caption
            };

            _context.Entry(newPost).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<UserPostDTO>> GetAllPosts()
        {
            var allPosts = await _context.UserPosts.ToListAsync();

            var filledList = FillUserPostDTO(allPosts).Result;

            return filledList;
        }

        public async Task<List<UserPostDTO>> GetAllUserPosts(string userId)
        {
            var allPosts = await _context.UserPosts.Where(x => x.UserId == userId)
                                                   .ToListAsync();

            var filledList = FillUserPostDTO(allPosts).Result;

            return filledList;
        }

        public async Task<UserPostDTO> GetASpecificPost(int postId)
        {
            var post = await _context.UserPosts.Where(x => x.ID == postId)                                               
                                               .FirstOrDefaultAsync();

            var comments = new List<PostCommentDTO>();
            var images = new List<PostImageDTO>();

            foreach (var item in post.PostComments)
            {
                comments.Add(await _postComment.GetASpecificComment(item.CommentId));
            }

            foreach (var item in post.PostImages)
            {
                images.Add(await _postImage.GetASpecificImage(item.ImageId));
            }

            var postDTO = new UserPostDTO() 
            {
                Id = post.ID,
                UserId = post.UserId,
                Caption = post.Caption,
                PostComments = comments,
                PostImages = images
                // TODO: Add Likes
            };

            return postDTO;
        }

        public async Task<UserPostDTO> Update(UserPostDTO post)
        {
            var originalPost = await GetASpecificPost(post.Id);


            UserPost updatedPost = new UserPost()
            {
                ID = post.Id,
                UserId = post.UserId,
                Caption = post.Caption
            };

            // ============ TODO: Will not test till this is done! ====================
            // Update the Comment list
            // Update the Image list
            // Update the Likes
            // ========================================================================

            _context.Entry(updatedPost).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task Delete(int postId)
        {
            var postToBeDeleted = await _context.UserPosts.FindAsync(postId);
            _context.Entry(postToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddALikeToPost(int postId, string userId)
        {
            PostLike like = new PostLike()
            {
                PostId = postId,
                UserId = userId
            };

            _context.Entry(like).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<LikeDTO> GetPostLikes(int postId, string userId)
        {
            var likes = await _context.PostLikes.Where(x => x.PostId == postId).ToListAsync();

            LikeDTO likeDTO = new LikeDTO()
            {
                NumberOfLikes = likes.Count,
                UserLiked = UserLiked(likes, userId)
            };

            return likeDTO;
        }

        private async Task<List<UserPostDTO>> FillUserPostDTO(List<UserPost> inputList)
        {
            var allPostsDTOs = new List<UserPostDTO>();

            foreach (var post in inputList)
            {
                var commentList = await _context.PostToComments.Where(x => x.PostId == post.ID).ToListAsync();

                var imageList = await _context.PostToImages.Where(x => x.PostId == post.ID).ToListAsync();

                var comments = new List<PostCommentDTO>();
                var images = new List<PostImageDTO>();

                foreach (var item in commentList)
                {
                    comments.Add(await _postComment.GetASpecificComment(item.CommentId));
                }

                foreach (var item in imageList)
                {
                    images.Add(await _postImage.GetASpecificImage(item.ImageId));
                }

                allPostsDTOs.Add(new UserPostDTO()
                {
                    Id = post.ID,
                    UserId = post.UserId,
                    Caption = post.Caption,
                    PostComments = comments,
                    PostImages = images
                    // TODO : PostLikes = getlikes                    
                });
            }

            return allPostsDTOs;
        }

        private bool UserLiked(List<PostLike> likes, string userId)
        {
            foreach (var item in likes)
            {
                if (item.UserId == userId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
