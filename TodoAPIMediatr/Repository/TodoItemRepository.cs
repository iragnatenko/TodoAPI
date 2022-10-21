using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Helpers;
using TodoAPIMediatr.Interfaces;

namespace TodoAPIMediatr.Repository
{
    public class TodoItemRepository : IRepository
    {
        private readonly DatabaseContext _dbContext;

        public TodoItemRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TodoItemEntity> GetAllItems()
        {
            try
            {
                return _dbContext.TodoItems.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TodoItemEntity GetById(long id)
        {
            try
            {
                TodoItemEntity? todo = _dbContext.TodoItems.Find(id);
                if (todo != null)
                {
                    return todo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        public long AddItem(TodoItemEntity todoItem)
        {
            try
            {
                _dbContext.TodoItems.Add(todoItem);
                _dbContext.SaveChanges();
                return todoItem.Id;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> DeleteItem(long id)
        {
            throw new NotImplementedException();
        }

        public TodoItemEntity UpdateItem(long id, TodoItemEntity item)
        {
            throw new NotImplementedException();
        }


    }

}
