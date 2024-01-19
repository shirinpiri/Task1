using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file, string fileName, string subDirectory);
    }
}
