using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// Creates a new Comment and puts it into the database
        /// </summary>
        /// <param name="postComment">The DTO to create the comment</param>
        /// <param name="userId">The userId who made the comment</param>
        /// <returns>If successful returns the DTO to the caller</returns>
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

        // =============== TODO =========================
        // 1. Add this to the interface
        // 2. Build unit tests for this method
        // 3. Summary comments on the Method and interface
        public async Task<List<PostCommentDTO>> GetAllComments()
        {
            var comments = await _context.PostComments.ToListAsync();

            var commentDTOs = new List<PostCommentDTO>();

            foreach (var comment in comments)
            {
                commentDTOs.Add(new PostCommentDTO()
                {
                    Id = comment.ID,
                    UserId = comment.UserId,
                    Body = comment.Body
                });
            }

            return commentDTOs;
        }

        /// <summary>
        /// Gets all the comments made by the specified user
        /// </summary>
        /// <param name="userId">The user's Id</param>
        /// <returns>A list of all the comments made by this user</returns>
        public async Task<List<PostCommentDTO>> GetAllUsersComments(string userId)
        {
            var comments = await _context.PostComments.Where(x => x.UserId == userId)
                                                      .ToListAsync();
            var commentDTOs = new List<PostCommentDTO>();
            foreach (var item in comments)
            {
                commentDTOs.Add(new PostCommentDTO()
                {
                    Id = item.ID,
                    UserId = item.UserId,
                    Body = item.Body
                });
            }

            return commentDTOs;
        }

        // ============ TODO: This may need to move to the Post Manager =============
        public async Task<List<PostCommentDTO>> GetCommentsForAPost(int postId)
        {
            var comments = await _context.PostComments.Where(x => x.ID == postId) // This is not correct.
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

        // =============================================================================

        /// <summary>
        /// Get a single specified comment
        /// </summary>
        /// <param name="commentId">The Id of the comment</param>
        /// <returns>A DTO of the specified comment</returns>
        public async Task<PostCommentDTO> GetASpecificComment(int commentId)
        {
            var comment = await _context.PostComments.Where(x => x.ID == commentId)
                                                     .FirstOrDefaultAsync();
            var commentDTO = new PostCommentDTO()
            {
                Id = comment.ID, 
                UserId = comment.UserId,
                Body = comment.Body
            };

            return commentDTO;
        }

        /// <summary>
        /// Updates a comments in the database
        /// </summary>
        /// <param name="postComment">The PostCommentDTO to be used to update the comment</param>
        /// <returns>If successful returns the updated PostCommentDTO</returns>
        public async Task<PostCommentDTO> Update(PostCommentDTO postComment, int commentId)
        {
            PostComment updateComment = new PostComment()
            {
                ID = postComment.Id,
                UserId = postComment.UserId,
                Body = postComment.Body
            };

            _context.Entry(updateComment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return postComment;
        }

        /// <summary>
        /// Deletes a comment from the database
        /// </summary>
        /// <param name="commentId">The Id of the comment to be deleted</param>
        /// <returns>Nothing</returns>
        public async Task Delete(int commentId)
        {
            PostComment commentToBeDeleted = await _context.PostComments.FindAsync(commentId);
            _context.Entry(commentToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a like to the comment
        /// </summary>
        /// <param name="commentId">The Id of the comment to be liked</param>
        /// <param name="userId">The user who is making the request</param>
        /// <returns>Nothing</returns>
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

        /// <summary>
        /// Gets the total number of likes for this comment and if the user who requested it has liked the comment
        /// </summary>
        /// <param name="commentId">The Id of the comment</param>
        /// <param name="userId">The Id of the user requesting this info</param>
        /// <returns>A LikeDTO which has the total number of likes and the a boolean</returns>
        public async Task<LikeDTO> GetCommentsLikes(int commentId, string userId)
        {            
            var likes = await _context.CommentLikes.Where(x => x.CommentId == commentId)                                                    
                                                   .ToListAsync();

            LikeDTO likeDTO = new LikeDTO() 
            { 
                NumberOfLikes = likes.Count, 
                UserLiked = UserLiked(likes, userId) 
            };

            return likeDTO;
        }

        /// <summary>
        /// Removes a like from a comment
        /// </summary>
        /// <param name="commentId">The Id of the comment</param>
        /// <param name="userId">The Id of the user who is making the request</param>
        /// <returns>Nothing</returns>
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
