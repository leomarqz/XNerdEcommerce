
using System.IO;

namespace XNerd.Ecommerce.Application.Models.ImageManagement
{
    public class ImageData
    {
        public string? Name { get; set; }
        public Stream? ImageStream { get; set; }
    }
}