using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Managers
{
    public class PostImageManager : IPostImage
    {


        public Task<PostImageDTO> Create(PostImageDTO postImage, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostImageDTO>> GetAllImages(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostImageDTO>> GetAnImagesForAPost(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostImageDTO> GetASpecificImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<PostImageDTO> Update(PostImageDTO postImage)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task AddLikeToImage(int imageId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<LikeDTO> GetImageLikes(int imageId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteALike(int imageId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
