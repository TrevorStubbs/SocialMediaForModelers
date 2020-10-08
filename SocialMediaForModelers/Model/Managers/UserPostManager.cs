using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Entities.JoinEntites;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Managers
{
    public class UserPostManager : IUserPost
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

        /// <summary>
        /// Create a new post and add it to the database
        /// </summary>
        /// <param name="post">A UserPostDTO to create the new entity</param>
        /// <returns>Returns the DTO if successful</returns>
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

        /// <summary>
        /// Gets all the posts from the database
        /// </summary>
        /// <returns>A list of Posts</returns>
        public async Task<List<UserPostDTO>> GetAllPosts()
        {
            var allPosts = await _context.UserPosts.ToListAsync();

            var filledList = FillUserPostDTO(allPosts).Result;

            return filledList;
        }

        /// <summary>
        /// Gets all the posts created by a specified user
        /// </summary>
        /// <param name="userId">The user's Id string</param>
        /// <returns>A list of the User's Posts</returns>
        public async Task<List<UserPostDTO>> GetAllUserPosts(string userId)
        {
            var allPosts = await _context.UserPosts.Where(x => x.UserId == userId)
                                                   .ToListAsync();

            var filledList = FillUserPostDTO(allPosts).Result;

            return filledList;
        }

        /// <summary>
        /// Gets a specific post from the database
        /// </summary>
        /// <param name="postId">The Id of the post</param>
        /// <returns>A single PostDTO</returns>
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

        /// <summary>
        /// Updates a post in the database
        /// </summary>
        /// <param name="post">The PostDTO needed to update the database</param>
        /// <returns>If successful the updated DTO</returns>
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

        /// <summary>
        /// Deletes a Post from the database
        /// </summary>
        /// <param name="postId">The Id of the post</param>
        /// <returns>Returns nothing</returns>
        public async Task Delete(int postId)
        {
            var postToBeDeleted = await _context.UserPosts.FindAsync(postId);
            _context.Entry(postToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a like to a post
        /// </summary>
        /// <param name="postId">The Post's Id</param>
        /// <param name="userId">THe User's Id string</param>
        /// <returns>Nothing</returns>
        public async Task AddALikeToAPost(int postId, string userId)
        {
            PostLike like = new PostLike()
            {
                PostId = postId,
                UserId = userId
            };

            _context.Entry(like).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the likes associated to this post
        /// </summary>
        /// <param name="postId">The Post's Id</param>
        /// <param name="userId">The Users Id who is making the request</param>
        /// <returns>A LikeDTO</returns>
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

        /// <summary>
        /// Deletes a like from a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="userId">The user's Id who is making the request</param>
        /// <returns>Nothing</returns>
        public async Task DeleteALike(int postId, string userId)
        {
            var like = await _context.PostLikes.Where(x => x.PostId == postId && x.UserId == userId).FirstOrDefaultAsync();

            _context.Entry(like).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds an image to a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="imageId">The image's id</param>
        /// <returns>Nothing</returns>
        public async Task AddAnImageToAPost(int postId, int imageId)
        {
            PostToImage newImageJoin = new PostToImage()
            {
                PostId = postId,
                ImageId = imageId
            };

            _context.Entry(newImageJoin).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an image from a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="imageId">The image's id</param>
        /// <returns>Nothing</returns>
        public async Task DeleteAnImageFromAPost(int postId, int imageId)
        {
            var like = await _context.PostToImages.FirstOrDefaultAsync(x => x.PostId == postId && x.ImageId == imageId);

            _context.Entry(like).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a comment to a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="commentId">The comment's id</param>
        /// <returns>Noting</returns>
        public async Task AddACommentToAPost(int postId, int commentId)
        {
            PostToComment comment = new PostToComment()
            {
                PostId = postId,
                CommentId = commentId
            };

            _context.Entry(comment).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a comment from a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="commentId">The comment's id</param>
        /// <returns>Nothing</returns>
        public async Task DeleteACommentFromAPost(int postId, int commentId)
        {
            var comment = await _context.PostToComments.FirstOrDefaultAsync(x => x.PostId == postId && x.CommentId == commentId);

            _context.Entry(comment).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Helper method to fill a list UserPostDTO from a list of UserPost.
        /// </summary>
        /// <param name="inputList">The list of UserPosts to be converted</param>
        /// <returns>A list of UserPostDTOs</returns>
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

        /// <summary>
        /// Helper Method to get likes information
        /// </summary>
        /// <param name="likes">A list of PostLikes</param>
        /// <param name="userId">The user's id who is making the request</param>
        /// <returns>A bool based if the user has liked the post</returns>
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
