using iTextSharp.text.pdf;
using System.IO;


namespace AsposePDF
{
    public class ReadOnlyFields
    {
        public void MakeFieldsReadOnly(string oldFile, string newFile, string[] fieldsToDisable)
        {
            PdfReader reader = new PdfReader(oldFile);
            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(newFile, FileMode.Create)))
            {
                AcroFields fields = stamper.AcroFields;
                SetFieldProperty(fields, fieldsToDisable);
            }
        }
        public void SetFieldProperty(AcroFields fields, string[] fieldsToDisable)
        {
            for (int i = 0; i < fieldsToDisable.Length; i++)
            {
                fields.SetFieldProperty(fieldsToDisable[i], "setfflags", PdfFormField.FF_READ_ONLY, null);
            }
        }
    }
}

