using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Interfaces
{
    public interface IAmazonS3Provider
    {
        Task<PutBucketResponse> CreateS3Bucket(string bucketName);
        //{
        //    PutBucketRequest newBucket = new PutBucketRequest()
        //    {
        //        BucketName = bucketName
        //    };

        //    return 
        //}
        Task<DeleteBucketResponse> DeleteS3Bucket(string bucketName);

        Task<GetObjectResponse> GetS3Object(string imageId);

    }
}
