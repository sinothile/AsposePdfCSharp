using Aspose.Pdf.Cloud.Sdk.Api;
using Aspose.Pdf.Cloud.Sdk.Model;
using System.Configuration;

namespace AsposePDF
{
    public class FilePopulator
    {
        public readonly string _apiKey;
        public readonly string _appSid;
        public FilePopulator()
        {
            _apiKey = ConfigurationManager.AppSettings["APIKEY"];
            _appSid = ConfigurationManager.AppSettings["APPSID"];
        }
        public FieldsResponse PopulateFile(string fileName, Fields fileFieldsAndValues)
        {
            PdfApi target = new PdfApi(_apiKey, _appSid);
            FieldsResponse apiResponse = target.PutUpdateFields(fileName, fileFieldsAndValues);

            if (ApiResponseIsNotNullAndStatusIsOK(apiResponse))
            {
                Fields field = apiResponse.Fields;
            }
            return apiResponse;
        }
        public bool ApiResponseIsNotNullAndStatusIsOK(FieldsResponse apiResponse)
        {
            return apiResponse != null && apiResponse.Status.Equals("OK");
        }
    }
}
