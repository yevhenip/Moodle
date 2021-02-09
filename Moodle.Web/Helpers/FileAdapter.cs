using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moodle.Core.Interfaces.Common;

namespace Moodle.Web.Helpers
{
    public class FileAdapter : IFile
    {
        private readonly IFormFile _file;
        public long Length => _file.Length;
        public string FileName => _file.FileName;
        public byte[] FileContents { get; set; }

        public FileAdapter(IFormFile file)
        {
            _file = file;
        }

        public Stream OpenReadStream()
        {
            return _file.OpenReadStream();
        }

        public void CopyTo(Stream target)
        {
            _file.CopyTo(target);
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return _file.CopyToAsync(target, cancellationToken);
        }
    }
}