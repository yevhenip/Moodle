using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Core.Interfaces.Common;

namespace Moodle.Core.Interfaces.Services
{
    public interface IMainFileService
    {
        IEnumerable<string> PickExtensions(IEnumerable<string> fileNames);
        IEnumerable<string> GetMainFiles(string webRootPath);
        Task AddMainFilesAsync(IEnumerable<IFile> files, string webRootPath);
        Task DeleteMainFile(string filePath);
    }
}