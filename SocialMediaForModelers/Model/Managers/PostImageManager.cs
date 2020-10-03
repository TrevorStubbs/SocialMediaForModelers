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

        public PostImageManager(SMModelersContext context)
        {
            _context = context;
        }

        public async Task<PostImageDTO> Create(PostImageDTO postImage, string userId)
        {
            PostImage newImage = new PostImage()
            {
                ID = postImage.Id,
                UserId = postImage.UserId,
                ImageURI = postImage.ImageURI
            };

            // call method to put the image into the S3 bucket

            _context.Entry(newImage).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return postImage;
        }

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
                    ImageURI = item.ImageURI
                });
            }

            return imageList;
        }

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
                    ImageURI = item.ImageURI
                });
            }

            return imageList;
        }

        // ============= This may need to be moved to the Post Manager ===================
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
                    ImageURI = item.ImageURI
                });
            }

            return imageList;
        }

        public async Task<PostImageDTO> GetASpecificImage(int imageId)
        {
            var image = await _context.PostImages.Where(x => x.ID == imageId).FirstOrDefaultAsync();
            var imageDTO = new PostImageDTO()
            {
                Id = image.ID,
                UserId = image.UserId,
                ImageURI = image.ImageURI
            };

            return imageDTO;
        }

        public async Task<PostImageDTO> Update(PostImageDTO postImage)
        {
            PostImage updateImage = new PostImage()
            {
                ID = postImage.Id,
                UserId = postImage.UserId,
                ImageURI = postImage.ImageURI
            };
            _context.Entry(updateImage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return postImage;
        }
        public async Task Delete(int imageId)
        {
            PostImage imageToBeDeleted = await _context.PostImages.FindAsync(imageId);
            _context.Entry(imageToBeDeleted).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
