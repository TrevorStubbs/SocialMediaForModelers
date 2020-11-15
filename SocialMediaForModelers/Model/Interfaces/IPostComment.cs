using SocialMediaForModelers.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface IPostComment
    {
        // Create
        /// <summary>
        /// Creates a new Comment and puts it into the database
        /// </summary>
        /// <param name="postComment">The DTO to create the comment</param>
        /// <param name="userId">The userId who made the comment</param>
        /// <returns>If successful returns the DTO to the caller</returns>
        Task<PostCommentDTO> Create(PostCommentDTO postComment, string userId);

        /// <summary>
        /// Gets all comments from the database.
        /// </summary>
        /// <returns>A list of PostCommentDTOs</returns>
        Task<List<PostCommentDTO>> GetAllComments();

        // ReadUsersComments
        /// <summary>
        /// Gets all the comments made by the specified user
        /// </summary>
        /// <param name="userId">The user's Id</param>
        /// <returns>A list of all the comments made by this user</returns>
        Task<List<PostCommentDTO>> GetAllUsersComments(string userId);

        // ReadSpecificComment
        /// <summary>
        /// Get a single specified comment
        /// </summary>
        /// <param name="commentId">The Id of the comment</param>
        /// <returns>A DTO of the specified comment</returns>
        Task<PostCommentDTO> GetASpecificComment(int commentId);

        // ReadPostsComments
        // TODO: Move this to posts
        Task<List<PostCommentDTO>> GetCommentsForAPost(int postId);

        // Update
        /// <summary>
        /// Updates a comments in the database
        /// </summary>
        /// <param name="postComment">The PostCommentDTO to be used to update the comment</param>
        /// <returns>If successful returns the updated PostCommentDTO</returns>
        Task<PostCommentDTO> Update(PostCommentDTO postComment, int commentId);

        // Delete
        /// <summary>
        /// Deletes a comment from the database
        /// </summary>
        /// <param name="commentId">The Id of the comment to be deleted</param>
        /// <returns>Nothing</returns>
        Task Delete(int commentId);

        // Add Like To comment
        /// <summary>
        /// Adds a like to the comment
        /// </summary>
        /// <param name="commentId">The Id of the comment to be liked</param>
        /// <param name="userId">The user who is making the request</param>
        /// <returns>Nothing</returns>
        Task AddLikeToComment(int commentId, string userId);

        // GetLikes
        // only needs a number of likes and if the user who is viewing this comment is a person who has added a like.
        /// <summary>
        /// Gets the total number of likes for this comment and if the user who requested it has liked the comment
        /// </summary>
        /// <param name="commentId">The Id of the comment</param>
        /// <param name="userId">The Id of the user requesting this info</param>
        /// <returns>A LikeDTO which has the total number of likes and the a boolean</returns>
        Task<LikeDTO> GetCommentsLikes(int commentId, string userId);

        // DeleteALike
        /// <summary>
        /// Removes a like from a comment
        /// </summary>
        /// <param name="commentId">The Id of the comment</param>
        /// <param name="userId">The Id of the user who is making the request</param>
        /// <returns>Nothing</returns>
        Task DeleteALike(int commentId, string userId);
    }
}
