using FileUpload.Models;
using Microsoft.Extensions.Options;

namespace FileUpload.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly StorageSettings _storage;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FileUploadService> _logger;

        public FileUploadService(
            IOptions<StorageSettings> options,
            IWebHostEnvironment env,
            ILogger<FileUploadService> logger)
        {
         _storage = options.Value;
         _env = env;
         _logger = logger;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file != null && file.Length != 0)
            {

                if (IsJpeg(file))
                {


                    string pathForDb = "";

                    try
                    {
                        pathForDb = Path.Combine(_storage.ContentPath + Guid.NewGuid().ToString()
                            + file.FileName.Substring(file.FileName.LastIndexOf(".")));

                        var fullname = Path.Combine(_env.WebRootPath, pathForDb);

                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(fullname, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                                _logger.LogInformation("Dosya yükleme işlemi başarılı", file.FileName);
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex.Message, file.FileName);

                        return null;
                    }

                    return "/" + pathForDb;
                }
                _logger.LogWarning("Dosya uzantısı doğru değil");
                return "Dosya uzantısı doğru değil";
            }
            _logger.LogWarning("Dosya boş olamaz");

            return null;
        }

        private bool IsJpeg(IFormFile file)
        {
            return file.ContentType.ToLower() == "image/jpeg" ||
                   file.ContentType.ToLower() == "image/jpg";
        }


    }
}

