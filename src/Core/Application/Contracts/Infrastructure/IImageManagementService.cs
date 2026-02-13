
using System.Threading.Tasks;

using XNerd.Ecommerce.Application.Models.ImageManagement;

namespace XNerd.Ecommerce.Application.Contracts.Infrastructure
{
    public interface IImageManagementService
    {
        Task<ImageResponse> UploadImageAsync( ImageData imageData );
    }
}