using SocialMediaForModelers.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface IUserPost
    {
        // PostCRUD
        //  Create a Post
        Task<UserPostDTO> Create(UserPostDTO post, string userId);

        //  GetAllPosts
        Task<List<UserPostDTO>> GetAllPosts();

        //  GetAllOfAUsersPosts
        Task<List<UserPostDTO>> GetAllUserPosts(string userId);

        //  GetASpecificPost
        Task<UserPostDTO> GetASpecificPost(int postId);

        //  Update
        Task<UserPostDTO> Update(UserPostDTO post);

        //  Delete a Post
        Task Delete(int postId);

        // LikeCRUD
        //  Add a like to a post
        Task AddALikeToAPost(int postId, string userId);

        //  Get the number of likes for a post
        Task<LikeDTO> GetPostLikes(int postId, string userId);

        //  Delete a like from a post
        Task DeleteALike(int postId, string userId);

        // Image Join Table CRUD
        //  Add an image to a post
        Task AddAnImageToAPost(int postId, int imageId);

        //  Delete an image from a post
        Task DeleteAnImageFromAPost(int postId, int imageId);

        // Comment Join Table CRUD
        //  Add a comment to a post
        Task AddACommentToAPost(int postId, int commentId);

        //  Delete a comment from a post
        Task DeleteACommentFromAPost(int postId, int commentId);
    }
}
