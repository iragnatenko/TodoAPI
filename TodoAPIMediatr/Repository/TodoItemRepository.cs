using Microsoft.EntityFrameworkCore;
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

        public TodoItemEntity UpdateItem(TodoItemEntity item)
        {
            try
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return item;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteItem(long id)
        {
            try
            {
                TodoItemEntity? todo = _dbContext.TodoItems.Find(id);

                if (todo != null)
                {
                    _dbContext.TodoItems.Remove(todo);
                    _dbContext.SaveChanges();
                    return true;
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

        public bool CheckTodo(long id)
        {
            return _dbContext.TodoItems.Any(e => e.Id == id);
        }
    
    }

}
