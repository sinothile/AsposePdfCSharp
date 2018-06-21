using Aspose.Pdf.Cloud.Sdk.Model;
using AsposePDF;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;


namespace AsposeTests
{
    [TestFixture]
    public class PdfAsposeTests
    {
        [Test]
        public void UploadPdf_GivenPdfFileNameThatDoesNotExist_ShouldReturnStatusCode404()
        {
            //Arrange
            var sut = new FileUploader();
            string name = "me.pdf";
            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var pdfPath = Path.Combine(baseDirectory, name);

            //Act
            var actual = sut.UploadPdf(pdfPath, name);

            //Assert
            Assert.AreEqual(404, actual.Code);
        }

        [Test]
        public void UploadPdf_GivenPathAndFileName_ShouldUploadFileAndReturnStatusCode200()
        {
            //Arrange
            var sut = new FileUploader();
            string name = "AsposePDF.pdf";
            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var pdfPath = Path.Combine(baseDirectory, name);

            //Act
            var actual = sut.UploadPdf(pdfPath, name);

            //Assert
            Assert.AreEqual(200, actual.Code);
        }

        [Test]
        public void PopulateFile_GivenFileNameFieldsAndValues_ShouldPopulateFieldsAndReturnStatusOK()
        {
            //Arrange
            var sut = new FilePopulator();
            var fileName = "AsposeBootCampForm.pdf";
            Fields fileFieldsAndValues = GetFieldsAndValues();

            //Act
            var actual = sut.PopulateFile(fileName, fileFieldsAndValues);

            //Assert
            Assert.AreEqual("OK", actual.Status);
        }

        [Test]
        public void MakeFieldsReadOnly_GivenOldFilePathAndNewFilePathWithFieldsToDisable_ShouldDisableFieldsAndNewFileByteShouldBeBigger()
        {
            //Arrange
            var sut = new ReadOnlyFields();
            string oldFileName = "populatedAsposeBootCamp.pdf";
            string newFileName = "Readonly.pdf.pdf";
            string [] fieldsToDisable = new string[] {"FirstName", "Surname", "Date_of_birth" };

            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var oldFilePath = Path.Combine(baseDirectory, oldFileName);
            var newFilePath = Path.Combine(baseDirectory, newFileName);

            //Act
            sut.MakeFieldsReadOnly(oldFilePath, newFilePath, fieldsToDisable);

            //Assert
            var originalBytes = File.ReadAllBytes(oldFilePath);
            var readonlyBytes = File.ReadAllBytes(newFilePath);
            Assert.AreNotEqual(originalBytes, readonlyBytes);
        }

        [Test]
        public void DownloadFile_GivenFileToDownloadAndPathToStoreTheFile_ShouldDownloadFileAndBothFilesShouldHaveEqualBytesLength()
        {
            //Arrange
            var sut = new FileDownloader();
            string fileToDownload = "AsposeBootCampForm.pdf";
            string downloadedFileName = "downloaded.pdf";
            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var path = Path.Combine(baseDirectory, downloadedFileName);

            //Act
            var actual = sut.DownloadFile(fileToDownload, path);

            //Assert
            var fileToDownloadBytesLength = actual.Length;
            var downloadedFileBytes = File.ReadAllBytes(path);
            var downloadedFileBytesLength = downloadedFileBytes.Length;

            Assert.AreEqual(fileToDownloadBytesLength, downloadedFileBytesLength);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void DownloadFile_GivenEmptyFileNameToDownload_ShouldReturnByteOf0(string fileToDownload)
        {
            //Arrange
            var sut = new FileDownloader();
            string downloadedFileName = "downloaded.pdf";
            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var path = Path.Combine(baseDirectory, downloadedFileName);

            //Act
            var actual = sut.DownloadFile(fileToDownload, path);

            //Assert
            var expected = new byte[0];
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DownloadFile_GivenFileNameThatDoesNotExist_ShouldReturnByteOf0()
        {
            //Arrange
            var sut = new FileDownloader();
            string fileToDownload = "Invalid.pdf";
            string downloadedFileName = "downloaded.pdf";
            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var path = Path.Combine(baseDirectory, downloadedFileName);

            //Act
            var actual = sut.DownloadFile(fileToDownload, path);

            //Assert
            var expected = new byte[0];
            Assert.AreEqual(expected, actual);
        }
        public Fields GetFieldsAndValues()
        {
            return new Fields
            {
                List = new List<Field>
                {
                    new Field
                    {
                        Name = "FirstName",
                        Values = new List<string>
                        {
                            "Sinothile"
                        }
                    },
                    new Field
                    {
                        Name = "Surname",
                        Values = new List<string>
                        {
                            "Mbatha"
                        }
                    },
                    new Field
                    {
                        Name = "Date_of_birth",
                        Values = new List<string>
                        {
                            "05/05/2020"
                        }
                    },
                     new Field
                     {
                        Name = "Tax",
                        Values = new List<string>
                        {
                            "50"
                        }

                      },
                     new Field
                      {
                      Name = "GrossSalary",
                      Values = new List<string>
                      {
                           "100"
                      }

                      },
                     new Field
                     {
                     Name = "AccomodationCost",
                     Values = new List<string>
                     {
                           "10"
                     }

                     },
                      new Field
                     {
                     Name = "CellPhoneCost",
                     Values = new List<string>
                     {
                          "10"
                     }

                     },
                      new Field
                      {
                      Name = "CreditCardCost",
                      Values = new List<string>
                      {
                          "10"
                      }

                      },
                      new Field
                      {
                      Name = "OtherDebitCost",
                      Values = new List<string>
                      {
                          "10"
                      }

                      }
                  }

            };
        }
    }
}



