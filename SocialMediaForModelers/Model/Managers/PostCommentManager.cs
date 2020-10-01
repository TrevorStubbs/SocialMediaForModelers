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
    public class PostCommentManager : IPostComment
    {
        private SMModelersContext _context;

        public PostCommentManager(SMModelersContext context)
        {
            _context = context;
        }

        public async Task<PostCommentDTO> Create(PostCommentDTO postComment, string userId)
        {
            PostComment newComment = new PostComment()
            {
                ID = postComment.Id,
                UserId = postComment.UserId,
                Body = postComment.Body
            };

            _context.Entry(newComment).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return postComment;
        }

        public async Task<List<PostCommentDTO>> GetAllUsersComments(string userId)
        {
            var comments = await _context.PostComments.Where(x => x.UserId == userId)
                                                      .ToListAsync();
            var commentDTOs = new List<PostCommentDTO>();
            foreach (var item in commentDTOs)
            {
                commentDTOs.Add(new PostCommentDTO()
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    Body = item.Body
                });
            }

            return commentDTOs;
        }

        public async Task<List<PostCommentDTO>> GetCommentsForAPost(int postComment)
        {
            var comments = await _context.PostComments.Where(x => x.ID == postComment)
                                                      .ToListAsync();
            var commentDTOs = new List<PostCommentDTO>();
            foreach (var item in commentDTOs)
            {
                commentDTOs.Add(new PostCommentDTO()
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    Body = item.Body
                });
            }

            return commentDTOs;
        }

        public async Task<PostCommentDTO> GetASpecificComment(int postComment, string userId)
        {
            var comment = await _context.PostComments.Where(x => x.ID == postComment && x.UserId == userId)
                                                     .FirstOrDefaultAsync();
            var commentDTO = new PostCommentDTO()
            {
                Id = comment.ID, 
                UserId = comment.UserId,
                Body = comment.Body
            };

            return commentDTO;
        }

        public async Task<PostCommentDTO> Update(PostCommentDTO postComment)
        {
            PostComment newComment = new PostComment()
            {
                ID = postComment.Id,
                UserId = postComment.UserId,
                Body = postComment.Body
            };
            _context.Entry(newComment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return postComment;

        }

        public async Task Delete(int commentId)
        {
            PostComment commentToBeDeleted = await _context.PostComments.FindAsync(commentId);
            _context.Entry(commentToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddLikeToComment(int commentId, string userId)
        {
            CommentLike newLike = new CommentLike()
            {
                CommentId = commentId,
                UserId = userId
            };

            _context.Entry(newLike).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<LikeDTO> GetCommentsLikes(int commentId, string userId)
        {            
            var likes = await _context.CommentLikes.Where(x => x.CommentId == commentId)                                                    
                                                   .ToListAsync();

            LikeDTO likeDTO = new LikeDTO() 
            { 
                NumberOfLikes = likes.Count(), 
                UserLiked = UserLiked(likes, userId) 
            };

            return likeDTO;
        }

        public async Task DeleteALike(int commentId, string userId)
        {
            var like = await _context.CommentLikes.Where(x => x.CommentId == commentId && x.UserId == userId)
                                                  .FirstOrDefaultAsync();

            _context.Entry(like).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


        private bool UserLiked(List<CommentLike> likes, string userId)
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
