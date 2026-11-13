using System;
using System.Collections.Generic;
using System.IO;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public static class FileContentTypes
    {
        public const string Default = "application/octet-stream";

        private static readonly IDictionary<string, string> _contentTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".png", "image/png" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".gif", "image/gif" },
            { ".webp", "image/webp" },
            { ".bmp", "image/bmp" },
            { ".svg", "image/svg+xml" },
            { ".pdf", "application/pdf" }
        };

        public static string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            if (!string.IsNullOrEmpty(extension) && _contentTypes.TryGetValue(extension, out var contentType))
            {
                return contentType;
            }

            return Default;
        }
    }
}
