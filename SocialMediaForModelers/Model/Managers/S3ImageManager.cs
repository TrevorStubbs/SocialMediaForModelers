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

        /// <summary>
        /// Needs an AWS AcessKey and Secret key, and needs a region to instantiate the AmazonS3Client
        /// </summary>
        /// <param name="config">This data comes from user secrets</param>
        public S3ImageManager(IConfiguration config)
        {
            _config = config;
            _s3Client = new AmazonS3Client(config["AWSS3:AccessKeyId"], config["AWSS3:SecretKey"], _region);
        }

        /// <summary>
        /// Takes an image object and places it into the AWS S3 bucket.
        /// </summary>
        /// <param name="imageId">The imageId from the app database</param>
        /// <param name="imageFile">The imageFile provided by the client</param>
        /// <returns>The HttpStatusCode</returns>
        public async Task<HttpStatusCode> AddAnImageToCloudStorage(string imageId, IFormFile imageFile)
        {
            try
            {
                PutObjectRequest imageRequest = new PutObjectRequest()
                {
                    BucketName = _config["AWSS3:StorageBucketName"],
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

        /// <summary>
        /// Generates a temporary image URL for the client to use.
        /// </summary>
        /// <param name="imageId">The imageId from the app database</param>
        /// <returns>The URL as a string</returns>
        public string GetImageUrl(string imageId)
        {
            try
            {
                GetPreSignedUrlRequest urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = _config["AWSS3:StorageBucketName"],
                    Key = imageId,
                    Expires = DateTime.UtcNow.AddMinutes(5) // change this to 1 hour
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

        /// <summary>
        /// Deletes an image object from the S3 bucket
        /// </summary>
        /// <param name="imageId">The imageId from the app database</param>
        /// <returns>An HTTP Response Code</returns>
        public async Task<HttpStatusCode> DeleteAnImageFromCloudStorage(string imageId)
        {
            try
            {
                DeleteObjectResponse response;
                DeleteObjectRequest deleteThisObject = new DeleteObjectRequest()
                {
                    BucketName = _config["AWSS3:StorageBucketName"],
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

        // -------------------- S3 Specific Methods ------------------------------
        /// <summary>
        /// Moves an image from the transfer bucket to the storage bucket with the appropriate key.
        /// </summary>
        /// <param name="tempTransferKey">The S3 object key of the image in the transfer bucket (provided by the client).</param>
        /// <param name="cloudStorageKey">The permanent object key</param>
        /// <returns>HttpStatusCode</returns>
        public async Task<HttpStatusCode> MoveImageFromTransferBucketToStorageBucket(string tempTransferKey, string cloudStorageKey)
        {
            try
            {
                var copyOjectResponse = await _s3Client.CopyObjectAsync(_config["AWSS3:TransferBucketName"], tempTransferKey, _config["AWSS3:StorageBucketName"], cloudStorageKey);

                if (copyOjectResponse.HttpStatusCode == HttpStatusCode.OK)
                {
                    var deleteObjectResponse = await _s3Client.DeleteObjectAsync(_config["AWSS3:TransferBucketName"], tempTransferKey);

                    if (deleteObjectResponse != null)
                    {
                        return HttpStatusCode.OK;
                    }
                    else
                    {
                        throw new Exception($"Transfer image '{tempTransferKey}' was not deleted from the transfer bucket. Response code '{deleteObjectResponse.HttpStatusCode}'");
                    }
                }
                else
                {
                    throw new Exception($"Image '{cloudStorageKey}' was not copied to the storage bucket. Response code '{copyOjectResponse.HttpStatusCode}'");
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

        /// <summary>
        /// Creates a new S3 Bucket.
        /// Bucket names must be unique across all existing bucket names.
        /// Bucket names must comply with DNS naming conventions.
        /// Bucket names must be at least 3 and no more than 63 characters long.
        /// Bucket names must not contain uppercase characters or underscores.
        /// Bucket names must start with a lowercase letter or number.
        /// Bucket names must be a series of one or more labels.Adjacent labels are separated by a single period (.). Bucket names can contain lowercase letters, numbers, and hyphens.Each label must start and end with a lowercase letter or a number.
        /// Bucket names must not be formatted as an IP address(for example, 192.168.5.4).
        /// </summary>
        /// <param name="bucketName">
        /// The bucket name
        /// </param>
        /// <returns>A PutBucketResponse Object</returns>
        public async Task<PutBucketResponse> CreateS3Bucket(string bucketName)
        {
            try
            {
                PutBucketRequest newBucket = new PutBucketRequest()
                {
                    BucketName = _config["AWSS3:StorageBucketName"]
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

        /// <summary>
        /// Deletes A specific bucket. (needs to be empty of objects)
        /// </summary>
        /// <param name="bucketName">The bucket's name</param>
        /// <returns>A DeleteBucketResponse Object</returns>
        public async Task<DeleteBucketResponse> DeleteS3Bucket(string bucketName)
        {
            try
            {
                DeleteBucketRequest deleteThisBucket = new DeleteBucketRequest()
                {
                    BucketName = _config["AWSS3:StorageBucketName"]
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

        /// <summary>
        /// Gets the whole GetObjectResponse object from AWS S3.
        /// </summary>
        /// <param name="imageId">The imageId from the database</param>
        /// <returns>A GetObjectResponse Object</returns>
        public async Task<GetObjectResponse> GetS3Object(string imageId)
        {
            try
            {
                GetObjectRequest itemRequest = new GetObjectRequest()
                {
                    BucketName = _config["AWSS3:StorageBucketName"],
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
