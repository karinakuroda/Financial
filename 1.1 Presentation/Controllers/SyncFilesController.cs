using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _1._1_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncFilesController : ControllerBase
    {
        private readonly IExcelReaderService _excelReaderService;
        private readonly ICsvReaderService _csvReaderService;

        public ICustomerService _customerService { get; }
        public IHostingEnvironment _hostingEnvironment { get; }

        public ProcessFileController(IExcelReaderService excelReaderService, ICustomerService customerService, IHostingEnvironment hostingEnvironment, ICsvReaderService csvReaderService)
        {
            this._excelReaderService = excelReaderService;
            _customerService = customerService;
            _hostingEnvironment = hostingEnvironment;
            _csvReaderService = csvReaderService;
        }

        [HttpPost]
        public IActionResult Csv()
        {
            Task.Run(() =>
            {
                var Filess = Request.Form.Files;
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                string fullPath = "";
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file.Length > 0)
                {
                    string fileName = Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var customerId = Convert.ToInt32(Path.GetFileNameWithoutExtension(fullPath));
                    _csvReaderService.ProcessCsv(fullPath, customerId);
                }
            });

            return Accepted();
        }


        [HttpPost]
        public IActionResult Xsl()
        {
            Task.Run(() =>
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                string fullPath = "";
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = Microsoft.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var customerId = Convert.ToInt32(Path.GetFileNameWithoutExtension(fullPath));
                    _excelReaderService.Process(fullPath, customerId);
                }
            });
        }
        
    }
}
