
using System;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

using XNerd.Ecommerce.Application.Contracts.Infrastructure;
using XNerd.Ecommerce.Application.Models.ImageManagement;

namespace XNerd.Ecommerce.Infrastructure.ImageCloudinary
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly Cloudinary _cloudinary;

        public ImageManagementService(IOptions<CloudinarySettings> cloudinarySettings)
        {
            var settings = cloudinarySettings.Value ?? 
                                throw new ArgumentNullException( nameof(CloudinarySettings) );

            var account = new Account( settings.CloudName, settings.APIKey, settings.APISecret );

            _cloudinary = new Cloudinary( account );
        }

        public async Task<ImageResponse> UploadImageAsync(ImageData imageData)
        {

            var uploadImage = new ImageUploadParams
            {
                File = new FileDescription( imageData.Name, imageData.ImageStream ),
                Folder = "xnerd_ecommerce_products"
            };

            ImageUploadResult? uploadResult = await _cloudinary.UploadAsync( uploadImage );

            if( uploadResult.Error != null )
                throw new Exception($"Cloudinary Upload Error: {uploadResult.Error.Message}");

            return new ImageResponse
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.Url.ToString()
            };

        }
    }
}