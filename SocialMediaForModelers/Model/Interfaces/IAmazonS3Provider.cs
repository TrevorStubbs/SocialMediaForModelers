using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface IAmazonS3Provider
    {
        // TransferImage
        /// <summary>
        /// Moves an image from the transfer bucket to the storage bucket with the appropriate key.
        /// </summary>
        /// <param name="tempTransferKey">The S3 object key of the image in the transfer bucket (provided by the client).</param>
        /// <param name="cloudStorageKey">The permanent object key</param>
        /// <returns>HttpStatusCode</returns>
        Task<HttpStatusCode> MoveImageFromTransferBucketToStorageBucket(string tempTransferKey, string cloudStorageKey);

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
        Task<PutBucketResponse> CreateS3Bucket(string bucketName);

        /// <summary>
        /// Deletes A specific bucket. (needs to be empty of objects)
        /// </summary>
        /// <param name="bucketName">The bucket's name</param>
        /// <returns>A DeleteBucketResponse Object</returns>
        Task<DeleteBucketResponse> DeleteS3Bucket(string bucketName);

        /// <summary>
        /// Gets the whole GetObjectResponse object from AWS S3.
        /// </summary>
        /// <param name="imageId">The imageId from the database</param>
        /// <returns>A GetObjectResponse Object</returns>
        Task<GetObjectResponse> GetS3Object(string imageId);

    }
}
