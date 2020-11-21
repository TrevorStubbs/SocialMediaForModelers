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
        /// <summary>
        /// Takes an image object and places it into the assigned cloud storage.
        /// </summary>
        /// <param name="imageId">The imageId from the app database</param>
        /// <param name="imageFile">The imageFile provided by the client</param>
        /// <returns>The HttpStatusCode</returns>
        Task<HttpStatusCode> AddAnImageToCloudStorage(string imageId, IFormFile imageFile);

        /// <summary>
        /// Generates a temporary image URL for the client to use.
        /// </summary>
        /// <param name="imageId">The imageId from the app database</param>
        /// <returns>The URL as a string</returns>
        string GetImageUrl(string imageId);

        /// <summary>
        /// Deletes an image object from the assigned cloud storage.
        /// </summary>
        /// <param name="imageId">The imageId from the app database</param>
        /// <returns>An HTTP Response Code</returns>
        Task<HttpStatusCode> DeleteAnImageFromCloudStorage(string imageId);

    }
}
