using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Moodle.Business.Extensions;
using Moodle.Core.Interfaces.Common;
using Moodle.Core.Interfaces.Services;

namespace Moodle.Business.Services
{
    public class MainFileService : IMainFileService
    {
        public IEnumerable<string> PickExtensions(IEnumerable<string> fileNames)
        {
            var extensions = fileNames.Select(Path.GetExtension).ToList();
            return extensions.PickExtensions();
        }

        public IEnumerable<string> GetMainFiles(string webRootPath)
        {
            var directoryInfo = new DirectoryInfo(webRootPath + @"\files\mainFiles");
            var files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                yield return file.Name;
            }
        }

        public async Task AddMainFilesAsync(IEnumerable<IFile> files, string webRootPath)
        {
            foreach (var file in files)
            {
                await using var fileStream = File.Create(webRootPath + @"\files\mainFiles\" + file.FileName);
                await file.CopyToAsync(fileStream);
            }
        }

        public async Task DeleteMainFile(string filePath)
        {
            await Task.Factory.StartNew(() => File.Delete(filePath));
        }
    }
}