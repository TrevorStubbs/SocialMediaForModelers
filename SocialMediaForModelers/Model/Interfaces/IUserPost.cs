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
        /// <summary>
        /// Create a new post and add it to the database
        /// </summary>
        /// <param name="post">A UserPostDTO to create the new entity</param>
        /// <returns>Returns the DTO if successful</returns>
        Task<UserPostDTO> Create(UserPostDTO post);

        //  GetAllPosts
        /// <summary>
        /// Gets all the posts from the database
        /// </summary>
        /// <returns>A list of Posts</returns>
        Task<List<UserPostDTO>> GetAllPosts();

        //  GetAllOfAUsersPosts
        /// <summary>
        /// Gets all the posts created by a specified user
        /// </summary>
        /// <param name="userId">The user's Id string</param>
        /// <returns>A list of the User's Posts</returns>
        Task<List<UserPostDTO>> GetAllUserPosts(string userId);

        //  GetASpecificPost
        /// <summary>
        /// Gets a specific post from the database
        /// </summary>
        /// <param name="postId">The Id of the post</param>
        /// <returns>A single PostDTO</returns>
        Task<UserPostDTO> GetASpecificPost(int postId);

        //  Update
        /// <summary>
        /// Updates a post in the database
        /// </summary>
        /// <param name="post">The PostDTO needed to update the database</param>
        /// <returns>If successful the updated DTO</returns>
        Task<UserPostDTO> Update(UserPostDTO post, int postId);

        //  Delete a Post
        /// <summary>
        /// Deletes a Post from the database
        /// </summary>
        /// <param name="postId">The Id of the post</param>
        /// <returns>Returns nothing</returns>
        Task Delete(int postId);

        // LikeCRUD
        //  Add a like to a post
        /// <summary>
        /// Adds a like to a post
        /// </summary>
        /// <param name="postId">The Post's Id</param>
        /// <param name="userId">THe User's Id string</param>
        /// <returns>Nothing</returns>
        Task AddALikeToAPost(int postId, string userId);

        //  Get the number of likes for a post
        /// <summary>
        /// Gets the likes associated to this post
        /// </summary>
        /// <param name="postId">The Post's Id</param>
        /// <param name="userId">The Users Id who is making the request</param>
        /// <returns>A LikeDTO</returns>
        Task<LikeDTO> GetPostLikes(int postId, string userId);

        //  Delete a like from a post
        /// <summary>
        /// Deletes a like from a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="userId">The user's Id who is making the request</param>
        /// <returns>Nothing</returns>
        Task DeleteALike(int postId, string userId);

        // Image Join Table CRUD
        //  Add an image to a post
        /// <summary>
        /// Adds an image to a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="imageId">The image's id</param>
        /// <returns>Nothing</returns>
        Task AddAnImageToAPost(int postId, int imageId);

        //  Delete an image from a post
        /// <summary>
        /// Deletes an image from a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="imageId">The image's id</param>
        /// <returns>Nothing</returns>
        Task DeleteAnImageFromAPost(int postId, int imageId);

        // Comment Join Table CRUD
        //  Add a comment to a post
        /// <summary>
        /// Adds a comment to a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="commentId">The comment's id</param>
        /// <returns>Noting</returns>
        Task AddACommentToAPost(int postId, int commentId);

        //  Delete a comment from a post
        /// <summary>
        /// Deletes a comment from a post
        /// </summary>
        /// <param name="postId">The post's id</param>
        /// <param name="commentId">The comment's id</param>
        /// <returns>Nothing</returns>
        Task DeleteACommentFromAPost(int postId, int commentId);
    }
}
