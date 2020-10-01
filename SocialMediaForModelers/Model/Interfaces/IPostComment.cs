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
        Task<PostCommentDTO> Create(PostCommentDTO postComment, string userId);

        // ReadUsersComments
        Task<List<PostCommentDTO>> GetAllUsersComments(string userId);

        // ReadPostsComments
        Task<List<PostCommentDTO>> GetCommentsForAPost(int commentId);

        // ReadSpecificComment
        Task<PostCommentDTO> GetASpecificComment(int commentId, string userId);

        // Update
        Task<PostCommentDTO> Update(PostCommentDTO postComment);

        // Delete
        Task Delete(int commentId);

        // Add Like To comment
        Task AddLikeToComment(int commentId, string userId);

        // GetLikes
        // only needs a number of likes and if the user who is viewing this comment is a person who has added a like.
        Task<LikeDTO> GetCommentsLikes(int commentId, string userId);

        // DeleteALike
        Task DeleteALike(int commentId, string userId);
    }
}
