using System.Collections;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers;

public class FileTypeHepper
{

    public static bool IsImage(IFormFile file)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return ((IList)allowedExtensions).Contains(extension);
    }

    public static bool IsQrCodeImage(IFormFile file)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return ((IList)allowedExtensions).Contains(extension);
    }

    public static bool IsDocument(IFormFile file)
    {
        var allowedExtensions = new[] { ".doc", ".docx", ".pdf", ".txt" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return ((IList)allowedExtensions).Contains(extension);
    }
}

//