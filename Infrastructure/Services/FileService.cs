using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {
        #region Property  
        private IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor  
        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region Upload File  
        public async Task<string> UploadFile(IFormFile file, string fileName, string subDirectory)
        {
            try
            {
                subDirectory = subDirectory ?? string.Empty;
                var target = Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory);
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }
                if (file.Length <= 0) return "file is empty";
                var filePath = Path.Combine(target, fileName + Path.GetExtension(file.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return "success";
            }
            catch
            {
                return "file not upload";
            }


        }
        #endregion

       
    }
}
