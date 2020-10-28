using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface IS3Image
    {
        // Add a bucket
        Task<string> AddABucket(string bucketName);
        // Delete a bucket
        Task DeleteABucket(string bucketName);
        // Add an image
        Task<string> AddAnImageToABucket();
        // Delete an image
        Task DeleteAnImageFromABucket(string imageId);
    }
}
