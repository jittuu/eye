using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;

namespace Eye.Web.Models
{
    public class UploadFileToBlobAction
    {
        public string ConnectionString { get; set; }

        public string FileName { get; set; }

        public IFormFile File { get; set; }

        public async Task RunAsync()
        {
            var storageAccount = CloudStorageAccount.Parse(ConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("images");

            if(!await container.ExistsAsync())
            {
                throw new InvalidOperationException("Container doesn't exist");
            }

            using (var fileStream = this.File.OpenReadStream())
            {
                var blockBlob = container.GetBlockBlobReference(FileName);
                blockBlob.Properties.ContentType = File.ContentType;
                await blockBlob.UploadFromStreamAsync(fileStream);
            }
        }
    }
}
