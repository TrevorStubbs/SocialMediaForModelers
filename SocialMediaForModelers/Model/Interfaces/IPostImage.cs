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
        Task<PostImageDTO> Create(PostImageDTO postImage, string userId);

        // Read
        // GetAllImages
        Task<List<PostImageDTO>> GetAllImages();

        // GetAllOfAUsersImages
        Task<List<PostImageDTO>> GetAllUsersImages(string userId);

        // GetAllImagesForAPost
        Task<List<PostImageDTO>> GetAllImagesForAPost(int postId);

        // GetAllASpecificImage
        Task<PostImageDTO> GetASpecificImage(int imageId);

        // Update
        Task<PostImageDTO> Update(PostImageDTO postImage);

        // Delete
        Task Delete(int imageId);

        // Add Like to Image
        Task AddLikeToImage(int imageId, string userId);

        // Get Likes
        Task<LikeDTO> GetImageLikes(int imageId, string userId);

        Task DeleteALike(int commentId, string userId);
    }
}
