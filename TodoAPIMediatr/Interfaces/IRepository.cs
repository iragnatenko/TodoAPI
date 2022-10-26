using TodoAPIMediatr.Entity;

namespace TodoAPIMediatr.Interfaces
{
    public interface IRepository
    {
        public List<TodoItemEntity> GetAllItems();
        public TodoItemEntity GetById(long id);
        public long AddItem(TodoItemEntity todoItem);
        public TodoItemEntity UpdateItem(TodoItemEntity item);
        public bool DeleteItem(long id);
        public bool CheckTodo(long id);

    }
}