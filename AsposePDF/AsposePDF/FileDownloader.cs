using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Storage.Cloud.Sdk.Model.Requests;
using RestSharp.Extensions;
using System;
using System.Configuration;
using System.IO;

namespace AsposePDF
{
    public class FileDownloader 
    {
        public readonly string _apiKey;
        public readonly string _appSid;
        public FileDownloader()
        {
            _apiKey = ConfigurationManager.AppSettings["APIKEY"];
            _appSid = ConfigurationManager.AppSettings["APPSID"];

        }
        public byte[] DownloadFile(string fileName, string path)
        {
            StorageApi storageApi = new StorageApi(_apiKey, _appSid);

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return new byte[0];
            }
            var request = new GetDownloadRequest(fileName);
            using (var response = storageApi.GetDownload(request))
            {
                if (response == null)
                {
                    return new byte[0];
                }
                var bytes = response.ReadAsBytes();
                File.WriteAllBytes(path, bytes);
                return bytes;
            }
                
        }

    }
}
