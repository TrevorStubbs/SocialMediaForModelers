using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Managers
{
    public class PostImageManager : IPostImage
    {
        private SMModelersContext _context;
        private ICloudImage _cloudImage;

        public PostImageManager(SMModelersContext context, ICloudImage cloudImage)
        {
            _context = context;
            _cloudImage = cloudImage;
        }

        /// <summary>
        /// Creates a new Image and puts it in the database
        /// </summary>
        /// <param name="postImage">The PostImageDTO to create the new entity</param>
        /// <param name="userId">The user's id</param>
        /// <returns>If successful: the new ImageDTO</returns>
        public async Task<PostImageDTO> Create(PostImageDTO postImage, string userId, IFormFile imageFile)
        {
            PostImage newImage = new PostImage()
            {
                UserId = postImage.UserId,
                CloudStorageKey = Guid.NewGuid().ToString()
            };

            _context.Entry(newImage).State = EntityState.Added;
            var success = await _context.SaveChangesAsync();

            if(success > 0)
            {
                await _cloudImage.AddAnImageToCloudStorage(newImage.CloudStorageKey, imageFile);
            }

            return postImage;
        }

        /// <summary>
        /// Gets all the images in the table from the database
        /// </summary>
        /// <returns>A list of all the images in the table</returns>
        public async Task<List<PostImageDTO>> GetAllImages()
        {
            var images = await _context.PostImages.ToListAsync();

            var imageList = new List<PostImageDTO>();

            foreach (var item in images)
            {
                imageList.Add(new PostImageDTO()
                {
                    Id = item.ID,
                    UserId = item.UserId,
                    ImageURI = _cloudImage.GetImageUrl(item.CloudStorageKey)
                });
            }

            return imageList;
        }

        /// <summary>
        /// Gets all the images posted by the specified user from the database
        /// </summary>
        /// <param name="userId">The User's Id</param>
        /// <returns>A list of all the users images</returns>
        public async Task<List<PostImageDTO>> GetAllUsersImages(string userId)
        {
            var images = await _context.PostImages.Where(x => x.UserId == userId).ToListAsync();

            var imageList = new List<PostImageDTO>();
            foreach (var item in images)
            {
                imageList.Add(new PostImageDTO()
                {
                    Id = item.ID,
                    UserId = item.UserId,
                    ImageURI = _cloudImage.GetImageUrl(item.CloudStorageKey)
                });
            }

            return imageList;
        }

        // ============= TODO: This may need to be moved to the Post Manager ===================
        public async Task<List<PostImageDTO>> GetAllImagesForAPost(int postId)
        {
            var images = await _context.PostImages.Where(x => x.ID == postId).ToListAsync();

            var imageList = new List<PostImageDTO>();
            foreach (var item in images)
            {
                imageList.Add(new PostImageDTO()
                {
                    Id = item.ID,
                    UserId = item.UserId,
                    ImageURI = _cloudImage.GetImageUrl(item.CloudStorageKey)
                });
            }

            return imageList;
        }
        // ===================================================================================

        /// <summary>
        /// Gets a specific Image from the database
        /// </summary>
        /// <param name="imageId">The Id of the image</param>
        /// <returns>A single PostImageDTO</returns>
        public async Task<PostImageDTO> GetASpecificImage(int imageId)
        {
            var image = await _context.PostImages.Where(x => x.ID == imageId).FirstOrDefaultAsync();
            var imageDTO = new PostImageDTO()
            {
                Id = image.ID,
                UserId = image.UserId,
                ImageURI = _cloudImage.GetImageUrl(image.CloudStorageKey)
            };

            return imageDTO;
        }

        /// <summary>
        /// Updates a specific image entry in the database
        /// </summary>
        /// <param name="postImage">A PostImageDTO to be use to update the DB</param>
        /// <returns>If successful the DTO gets sent back to the caller</returns>
        public async Task<PostImageDTO> Update(PostImageDTO postImage, int imageId)
        {
            PostImage updateImage = new PostImage()
            {
                ID = postImage.Id,
                UserId = postImage.UserId
            };

            var image = await _context.PostImages.Where(x => x.ID == postImage.Id).FirstOrDefaultAsync();

            updateImage.CloudStorageKey = image.CloudStorageKey;

            _context.Entry(updateImage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return postImage;
        }

        /// <summary>
        /// Deletes a specific image from the database
        /// </summary>
        /// <param name="imageId">The Id of the image to be deleted</param>
        /// <returns>Nothing</returns>
        public async Task Delete(int imageId)
        {            
            // Get the image
            PostImage imageToBeDeleted = await _context.PostImages.FindAsync(imageId);
            // Delete the image from S3
            await _cloudImage.DeleteAnImageFromCloudStorage(imageToBeDeleted.CloudStorageKey);
            // Delete the image entry from the Database
            _context.Entry(imageToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
