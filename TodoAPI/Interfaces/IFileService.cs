namespace TodoAPI.Interfaces
{
    public interface IFileService
    {
        Task<string> PdfToStringAsync();
        Task<bool> StringToPdfAsync(string base64str);

    }
}
