using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PWSlaba.Models;
using PWSlaba.Services.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace PWSlaba.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IEmailSender _emailSender;
        private readonly IFileService _fileService;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _logger = logger;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }
        [Route("home")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("about-us")]
        public IActionResult AboutUs()
        {
            return View();
        }
        [Route("feed-back")]
        public IActionResult FeedBack()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> SendEmail(MailModel mailModel)
        {
            await _emailSender.SendEmailAsync(mailModel.To, mailModel.ToName, "Feedback message", mailModel.Body);
            return RedirectToAction("Index");
        }
        [Route("uploadfiles")]
        public IActionResult UploadFiles()
        {
            var files = _fileService.GetFilesList(Path.Combine(this._webHostEnvironment.WebRootPath, "Files/"));

            return View(files);
        }

        [HttpGet]
        [Route("download-file")]
        public FileResult DownloadFile(string filename)
        {
            string path = Path.Combine(this._webHostEnvironment.WebRootPath, "Files/") + filename;

            var bytes = _fileService.GetFileDownload(path);

            return File(bytes, "application/octet-stream", filename);
        }
        [HttpPost]
        [Route("upload-file")]
        public async Task<IActionResult> UploadFile(IFormFile File)
        {
            var res = await _fileService.UploadFile(File, "wwwroot/Files");

            return RedirectToAction(nameof(UploadFiles));
        }
    }
}
