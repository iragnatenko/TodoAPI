using TodoAPI.Model;

namespace TodoAPI.Interfaces
{
    public interface IRepository
    {

        Task<IEnumerable<TodoItemDTO>> GetAllAsync();
        Task<TodoItemDTO> GetByIdAsync(long id);
        Task<TodoItemDTO> AddAsync(TodoItemDTO item);
        Task<TodoItemDTO> UpdateAsync(long id,TodoItemDTO item);
        Task<bool> DeleteAsync(long id);

     

    }
}
