using Microsoft.Extensions.Configuration;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Managers
{
    public class S3ImageManager : IS3Image
    {
        private IConfiguration _config;

        public S3ImageManager(IConfiguration config)
        {
            _config = config;
        }

        public Task<string> AddABucket(string bucketName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteABucket(string bucketName)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddAnImageToABucket()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAnImageFromABucket(string imageId)
        {
            throw new NotImplementedException();
        }
    }
}
