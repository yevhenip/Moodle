using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moodle.Core.Interfaces.Services;
using Moodle.Web.Helpers;
using Moodle.Web.Models;

namespace Moodle.Web.Pages.AdminPanel
{
    [Authorize("OnlyForAdmin")]
    public class MainFilePanel : PageModel
    {
        private readonly IMainFileService _fileService;
        private readonly string _webRootPath;

        public List<MainFileModel> Files { get; private set; } = new();
        public List<string> Types { get; private set; } = new ();

        [BindProperty]
        public IEnumerable<IFormFile> FormFiles { get; init; }

        public MainFilePanel(IMainFileService fileService, IWebHostEnvironment environment)
        {
            _fileService = fileService;
            _webRootPath = environment.WebRootPath;
        }

        public void OnGet()
        {
            var fileNames = _fileService.GetMainFiles(_webRootPath).ToList();
            Types = _fileService.PickExtensions(fileNames).ToList();
            foreach (var fileName in fileNames)
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                var path = @"files\mainFiles\" + fileName;
                MainFileModel file = new (path, fileNameWithoutExtension);
                Files.Add(file);
            }
            InitializeTempData();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string filePath)
        {
            Files = TempData.Get<List<MainFileModel>>("Files");
            Types = TempData.Get<List<string>>("Types");
            Files.RemoveAll(f => f.Path == filePath);
            TempData.Set("Files", Files);
            await _fileService.DeleteMainFile(_webRootPath + @"\" + filePath);
            return Page();
        }
        
        public async Task<IActionResult> OnPostCreateAsync()
        {
            var files = FormFiles.Select(file => new FileAdapter(file));
            await _fileService.AddMainFilesAsync(files, _webRootPath);
            TempData.Clear();

            return Redirect("/adminPanel/mainFilePanel");
        }

        private void InitializeTempData()
        {
            TempData.Set("Files", Files);
            TempData.Set("Types", Types);
        }
    }
}