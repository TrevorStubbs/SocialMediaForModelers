using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Data;
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
        private SMModelersContext _context;
        private ICloudImage _cloudImage;
        private IAmazonS3Provider _s3Provider;

        public PostImageManager(SMModelersContext context, ICloudImage cloudImage, IAmazonS3Provider amazonS3Provider)
        {
            _context = context;
            _cloudImage = cloudImage;
            _s3Provider = amazonS3Provider;
        }

        /// <summary>
        /// Creates a new PostImage and puts it in the database. If it's successfuly added then it transfers the image from the transfer bucket to the storage bucket.
        /// </summary>
        /// <param name="postImage">The CreatePostImageDTO to create the new entity</param>
        /// <param name="userId">The user's id</param>
        /// <returns>If successful: the new ImageDTO</returns>
        public async Task<PostImageDTO> Create(CreatePostImageDTO postImage, string userId)
        {
            var timeNow = DateTime.UtcNow;

            PostImage newImage = new PostImage()
            {
                UserId = userId,
                CloudStorageKey = $"{Guid.NewGuid()}{postImage.ImageExtention}",
                Created = timeNow,
                Modified = timeNow
            };

            _context.Entry(newImage).State = EntityState.Added;
            var success = await _context.SaveChangesAsync();

            if(success > 0)
            {
                await _s3Provider.MoveImageFromTransferBucketToStorageBucket(postImage.TransferKey, newImage.CloudStorageKey);
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
                    ImageURI = _cloudImage.GetImageUrl(item.CloudStorageKey),
                    Created = item.Created,
                    Modified = item.Modified
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
                    ImageURI = _cloudImage.GetImageUrl(item.CloudStorageKey),
                    Created = item.Created,
                    Modified = item.Modified
                });
            }

            return imageList;
        }

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
                ImageURI = _cloudImage.GetImageUrl(image.CloudStorageKey),
                Created = image.Created,
                Modified = image.Modified
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
                UserId = postImage.UserId,
                Created = postImage.Created
            };

            updateImage.Modified = DateTime.UtcNow;

            var image = await _context.PostImages.Where(x => x.ID == postImage.Id).FirstOrDefaultAsync();
                        
            updateImage.CloudStorageKey = image.CloudStorageKey;
            image.UserId = postImage.UserId;

            _context.Entry(image).State = EntityState.Modified;
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
            await DeleteImageFromPostToImageTable(imageId);

            PostImage imageToBeDeleted = await _context.PostImages.FindAsync(imageId);        
            
            await _cloudImage.DeleteAnImageFromCloudStorage(imageToBeDeleted.CloudStorageKey);            
            _context.Entry(imageToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Helper method to delete image from the PostToImages join table.
        /// </summary>
        /// <param name="imageId">The image's database id</param>
        /// <returns>Void</returns>
        private async Task DeleteImageFromPostToImageTable(int imageId)
        {
            var postToImageEntities = await _context.PostToImages.Where(x => x.ImageId == imageId).ToListAsync();

            foreach (var enitity in postToImageEntities)
            {
                _context.Entry(enitity).State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();
        }
    }
}
