using Microsoft.AspNetCore.Http;

namespace Infrastructure.EF.Services
{
    public class UploadFileService
    {
        public string UploadFileAsync(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
                var ImageAddress = $"\\images\\{file.FileName}";
                return ImageAddress;
            }

            return null;
        }
    }
}