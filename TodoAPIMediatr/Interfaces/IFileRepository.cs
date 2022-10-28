using TodoAPIMediatr.Entity;

namespace TodoAPIMediatr.Interfaces
{
    public interface IFileRepository
    {
        public string PdfToStringAsync();
        public string StringToPdfAsync (string base64String);
    }
}
