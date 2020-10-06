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

            var allPostDTOs = new List<UserPostDTO>();

            foreach (var post in allPosts)
            {
                var commentList = await _context.PostToComments.Where(x => x.PostId == post.ID).ToListAsync();

                var imageList = await _context.PostToImages.Where(x => x.PostId == post.ID).ToListAsync();

                List<PostCommentDTO> comments = new List<PostCommentDTO>();
                List<PostImageDTO> images = new List<PostImageDTO>();

                foreach (var item in commentList)
                {
                    comments.Add(await _postComment.GetASpecificComment(item.CommentId));
                }

                foreach (var item in imageList)
                {
                    images.Add(await _postImage.GetASpecificImage(item.ImageId));
                }

                allPostDTOs.Add(new UserPostDTO()
                {
                    Id = post.ID,
                    UserId = post.UserId,
                    Caption = post.Caption,
                    PostComments = comments,
                    PostImages = images
                    // TODO : PostLikes = getlikes                    
                });
            }

            return allPostDTOs;
        }

        public async Task<List<UserPostDTO>> GetAllUserPosts(string userId)
        {
            var allPosts = await _context.UserPosts.Where(x => x.UserId == userId).ToListAsync();

            var allPostsDTOs = new List<UserPostDTO>();

            foreach (var post in allPosts)
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
    }
}
