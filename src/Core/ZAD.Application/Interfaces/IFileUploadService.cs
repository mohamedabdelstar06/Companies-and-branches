using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ZAD.Application.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);
    }
}
