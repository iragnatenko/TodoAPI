namespace TodoAPI.Interfaces
{
    public interface ITodoService
    {
        Task<string> GetNameAsync();
    }
}
