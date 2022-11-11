using Microsoft.AspNetCore.Http;
using PWSlaba.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWSlaba.Services.Interfaces
{
    public interface IFileService
    {
        public List<FileModel> GetFilesList(string path);
        public byte[] GetFileDownload(string path);
        public Task<bool> UploadFile(IFormFile file, string savepath);
    }
}
