using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;
using System.Configuration;
using System.IO;

namespace AsposePDF
{
    public class FileUploader
    {
        public readonly string _apiKey;
        public readonly string _appSid;
        public FileUploader()
        {
            _apiKey = ConfigurationManager.AppSettings["APIKEY"];
            _appSid = ConfigurationManager.AppSettings["APPSID"];
        }
        public UploadResponse UploadPdf(string pdfPath, string name)
        {
            if (FileDoesNotExist(pdfPath))
            {
                var response = new UploadResponse();
                response.Code = 404;
                return response;
            }
            StorageApi storageApi = new StorageApi(_apiKey, _appSid);
            using (var stream = new FileStream(pdfPath, FileMode.Open))
            {
                var request = new PutCreateRequest(name, stream);
                var response = storageApi.PutCreate(request);
                return response;
            }
        }
        private static bool FileDoesNotExist(string pdfPath)
        {
            return !File.Exists(pdfPath);
        }
    }
}
