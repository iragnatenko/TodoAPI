using TodoAPIMediatr.Helpers;
using TodoAPIMediatr.Interfaces;

namespace TodoAPIMediatr.Repository
{
    public class FileRepository : IFileRepository
    {
        private string pathFrom = @"C:\Users\irynag.INFOSOLUTIONS\source\repos\From\SmallPDF.pdf";
        private string pathTo = @"C:\Users\irynag.INFOSOLUTIONS\source\repos\To\NewFile.pdf";

        public string PdfToStringAsync()
        {
            byte[] asBytes = File.ReadAllBytes(pathFrom);
            string s = Convert.ToBase64String(asBytes, 0, asBytes.Length);

            return s;
        }

        public string StringToPdfAsync(string base64str)
        {
            try
            {
                byte[] newBytes = Convert.FromBase64String(base64str);
                File.WriteAllBytes(pathTo, newBytes);
                return base64str;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

                throw;
            }

            return "NotOk";
        }
    }
}
