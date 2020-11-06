using Microsoft.AspNetCore.Http;
using SocialMediaForModelers.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface IPostImage
    {
        // Create
        /// <summary>
        /// Creates a new Image and puts it in the database
        /// </summary>
        /// <param name="postImage">The PostImageDTO to create the new entity</param>
        /// <param name="userId">The user's id</param>
        /// <returns>If successful: the new ImageDTO</returns>
        Task<PostImageDTO> Create(PostImageDTO postImage, string userId, IFormFile imageFile);

        // Read
        // GetAllImages - Will be Admin Only
        /// <summary>
        /// Gets all the images in the table from the database
        /// </summary>
        /// <returns>A list of all the images in the table</returns>
        Task<List<PostImageDTO>> GetAllImages();

        // GetAllOfAUsersImages
        /// <summary>
        /// Gets all the images posted by the specified user from the database
        /// </summary>
        /// <param name="userId">The User's Id</param>
        /// <returns>A list of all the users images</returns>
        Task<List<PostImageDTO>> GetAllUsersImages(string userId);

        // GetAllImagesForAPost
        // TODO: Move this to PostManager
        Task<List<PostImageDTO>> GetAllImagesForAPost(int postId);

        // GetAllASpecificImage
        /// <summary>
        /// Gets a specific Image from the database
        /// </summary>
        /// <param name="imageId">The Id of the image</param>
        /// <returns>A single PostImageDTO</returns>
        Task<PostImageDTO> GetASpecificImage(int imageId);

        // Update
        /// <summary>
        /// Updates a specific image in the database
        /// </summary>
        /// <param name="postImage">A PostImageDTO to be use to update the DB</param>
        /// <returns>If successful the DTO gets sent back to the caller</returns>
        Task<PostImageDTO> Update(PostImageDTO postImage, int imageId);

        // Delete
        /// <summary>
        /// Deletes a specific image from the database
        /// </summary>
        /// <param name="imageId">The Id of the image to be deleted</param>
        /// <returns>Nothing</returns>
        Task Delete(int imageId);
    }
}
