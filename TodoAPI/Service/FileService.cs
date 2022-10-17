using System.IO;
using TodoAPI.Controllers;
using TodoAPI.Data;
using TodoAPI.Interfaces;
using TodoAPI.Model;

namespace TodoAPI.Service
{
    public class FileService : IFileService
    {

        private string pathFrom = @"C:\Users\irynag\source\repos\From\SmallPDF.pdf";
        private string pathTo = @"C:\Users\irynag\source\repos\To\New.pdf";


        private readonly TodoContext _context;
        private readonly ILogger<FileController> _logger;
      

        public FileService(TodoContext context, ILogger<FileController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<string> PdfToStringAsync()
        {
            _logger.LogInformation("In the PdfToStringAsync 1");

            byte[] asBytes = File.ReadAllBytes(pathFrom);
            string s = Convert.ToBase64String(asBytes, 0, asBytes.Length);

            return s;
        }

        public async Task<bool> StringToPdfAsync(string base64str)
        {
            try
            {
                _logger.LogInformation("In the StringToPdfAsync 1");
                byte[] newBytes = Convert.FromBase64String(base64str);
                _logger.LogInformation("In the StringToPdfAsync 2");
                File.WriteAllBytes(pathTo, newBytes);
                _logger.LogInformation("In the StringToPdfAsync 3");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                throw;
            }
            //Byte[] bytes = File.ReadAllBytes(pathFrom);
            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            //base64str = await PdfToStringAsync();

            return true;
        }

    /*
    System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

    Image1.ImageUrl = "data:image/png;base64," + base64String;
        Image1.Visible = true;



    string s = Convert.ToBase64String(bytes); 
    Console.WriteLine("The base 64 string:\n   {0}\n", s);

    byte[] newBytes = Convert.FromBase64String(base64);
*/

    }
}
