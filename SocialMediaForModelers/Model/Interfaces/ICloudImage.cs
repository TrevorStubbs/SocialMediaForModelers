using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface ICloudImage
    {
        // Add an image
        Task<HttpStatusCode> AddAnImageToABucket(string imageId, IFormFile imageFile);
        // Get image url
        string GetImageUrl(string imageId);
        // Delete an image
        Task<HttpStatusCode> DeleteAnImageFromABucket(string imageId);
    }
}
