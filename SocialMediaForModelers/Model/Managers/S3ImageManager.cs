using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialMediaForModelers.Model.Managers
{
    public class S3ImageManager : ICloudImage, IAmazonS3Provider
    {
        private IAmazonS3 _s3Client;
        private IConfiguration _config;
        private readonly RegionEndpoint _region = RegionEndpoint.USWest2;

        public S3ImageManager(IConfiguration config)
        {
            _config = config;
            _s3Client = new AmazonS3Client(config["AWSS3:AccessKeyId"], config["AWSS3:SecretKey"], _region);
        }

        public async Task<HttpStatusCode> AddAnImageToABucket(string imageId, IFormFile imageFile)
        {
            try
            {
                PutObjectRequest imageRequest = new PutObjectRequest()
                {
                    BucketName = _config["AWSS3:BucketName"],
                    Key = imageId
                };

                PutObjectResponse response;

                using (Stream stream = imageFile.OpenReadStream())
                {
                    imageRequest.InputStream = stream;

                    response = await _s3Client.PutObjectAsync(imageRequest);
                }
                return response.HttpStatusCode;
            }
            catch (AmazonS3Exception e)
            {
                throw new AmazonS3Exception($"S3 Specific Message: {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Generic ASP.NET Message: {e.Message}");
            }

        }

        public string GetImageUrl(string imageId)
        {
            try
            {
                GetPreSignedUrlRequest urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = _config["AWSS3:BuckName"],
                    Key = imageId,
                    Expires = DateTime.UtcNow.AddHours(1)
                };

                return _s3Client.GetPreSignedURL(urlRequest);
            }
            catch (AmazonS3Exception e)
            {
                throw new AmazonS3Exception($"S3 Specific Message: {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Generic ASP.NET Message: {e.Message}");
            }

        }

        public async Task<HttpStatusCode> DeleteAnImageFromABucket(string imageId)
        {
            try
            {
                DeleteObjectResponse response;
                DeleteObjectRequest deleteThisObject = new DeleteObjectRequest()
                {
                    BucketName = _config["AWSS3:BucketName"],
                    Key = imageId
                };

                response = await _s3Client.DeleteObjectAsync(deleteThisObject);

                return response.HttpStatusCode;
            }
            catch (AmazonS3Exception e)
            {
                throw new AmazonS3Exception($"S3 Specific Message: {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Generic ASP.NET Message: {e.Message}");
            }
        }

        // -------------------- S3 Provider Methods ------------------------------

        public async Task<PutBucketResponse> CreateS3Bucket(string bucketName)
        {
            try
            {
                PutBucketRequest newBucket = new PutBucketRequest()
                {
                    BucketName = _config["AWSS3:BucketName"]
                };

                return await _s3Client.PutBucketAsync(newBucket);
            }
            catch (AmazonS3Exception e)
            {
                throw new AmazonS3Exception($"S3 Specific Message: {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Generic ASP.NET Message: {e.Message}");
            }
        }

        public async Task<DeleteBucketResponse> DeleteS3Bucket(string bucketName)
        {
            try
            {
                DeleteBucketRequest deleteThisBucket = new DeleteBucketRequest()
                {
                    BucketName = _config["AWSS3:BucketName"]
                };

                return await _s3Client.DeleteBucketAsync(deleteThisBucket);
            }
            catch (AmazonS3Exception e)
            {
                throw new AmazonS3Exception($"S3 Specific Message: {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Generic ASP.NET Message: {e.Message}");
            }
        }

        public async Task<GetObjectResponse> GetS3Object(string imageId)
        {
            try
            {
                GetObjectRequest itemRequest = new GetObjectRequest()
                {
                    BucketName = _config["AWSS3:BucketName"],
                    Key = imageId
                };

                using (GetObjectResponse objectResponse = await _s3Client.GetObjectAsync(itemRequest))
                {
                    return objectResponse;
                }
            }
            catch (AmazonS3Exception e)
            {
                throw new AmazonS3Exception($"S3 Specific Message: {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Generic ASP.NET Message: {e.Message}");
            }
        }
    }
}
