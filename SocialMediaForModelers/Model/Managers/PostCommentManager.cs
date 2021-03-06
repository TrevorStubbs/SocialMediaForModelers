﻿using Microsoft.EntityFrameworkCore;
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
            DateTime timeNow = DateTime.UtcNow;

            PostComment newComment = new PostComment()
            {
                ID = postComment.Id,
                UserId = postComment.UserId,
                Body = postComment.Body,
                Created = timeNow,
                Modified = timeNow
            };

            _context.Entry(newComment).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return postComment;
        }

        /// <summary>
        /// Gets all comments from the database.
        /// </summary>
        /// <returns>A list of PostCommentDTOs</returns>
        public async Task<List<PostCommentDTO>> GetAllComments()
        {
            var comments = await _context.PostComments.ToListAsync();

            return await FillPostCommentDTOs(comments);
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

            return await FillPostCommentDTOs(comments);
        }

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
                Body = comment.Body,
                Created = comment.Created,
                Modified = comment.Modified,
                CommentLikes = await GetCommentsLikes(commentId, comment.UserId)
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
            var comment = await _context.PostComments.Where(x => x.ID == commentId)
                                                     .FirstOrDefaultAsync();
            if (comment != null)
            {
                comment.ID = comment.ID;
                comment.UserId = postComment.UserId == null ? comment.UserId : postComment.UserId;
                comment.Body = postComment.Body == null ? comment.Body : postComment.Body;
                comment.Modified = DateTime.UtcNow;

                _context.Entry(comment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return await GetASpecificComment(commentId);
            }

            throw new Exception("The comment does not exist in the database.");
        }

        /// <summary>
        /// Deletes a comment from the database
        /// </summary>
        /// <param name="commentId">The Id of the comment to be deleted</param>
        /// <returns>Nothing</returns>
        public async Task Delete(int commentId)
        {
            await DeleteAllLikes(commentId);
            await DeletePostToCommentEntities(commentId);

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

        /// <summary>
        /// Helper method that fills a  list of PostCommentDTOs
        /// </summary>
        /// <param name="inputList">A list of PostComments</param>
        /// <returns>List of PostCommentDTOs</returns>
        private async Task<List<PostCommentDTO>> FillPostCommentDTOs(List<PostComment> inputList)
        {
            var commentDTOs = new List<PostCommentDTO>();

            foreach (var comment in inputList)
            {
                commentDTOs.Add(new PostCommentDTO()
                {
                    Id = comment.ID,
                    UserId = comment.UserId,
                    Body = comment.Body,
                    Created = comment.Created,
                    Modified = comment.Modified,
                    CommentLikes = await GetCommentsLikes(comment.ID, comment.UserId)
                }); ;
            }

            return commentDTOs;

        }

        /// <summary>
        /// Helper method that checks to see if the user requesting the likes has already liked the Post.
        /// </summary>
        /// <param name="likes">List of CommentLikes</param>
        /// <param name="userId">The user's id</param>
        /// <returns>True if the user liked the post</returns>
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

        /// <summary>
        /// Helper method that deletes all entities in the CommentLikes table when a comment it deleted.
        /// </summary>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>Void</returns>
        private async Task DeleteAllLikes(int commentId)
        {
            var likes = await _context.CommentLikes.Where(x => x.CommentId == commentId).ToListAsync();

            foreach (var like in likes)
            {
                _context.Entry(like).State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Helper method that deletes the comment's reference to the PostToComment join table.
        /// </summary>
        /// <param name="commentId">The comment's database Id</param>
        /// <returns>Void</returns>
        private async Task DeletePostToCommentEntities(int commentId)
        {
            var postToCommentEntities = await _context.PostToComments.Where(x => x.CommentId == commentId).ToListAsync();

            foreach (var entity in postToCommentEntities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();
        }
    }

}
