using BlazorAppTodoAPI.Interfaces;
using BlazorAppTodoAPI.Models;
using Newtonsoft.Json;

namespace BlazorAppTodoAPI.Services
{
    public class TodoItemService :ITodoItemService
    {

        private string urlGetAll = "https://localhost:7112/api/todoitems";
        private string urlGetById = "https://localhost:7112/api/todoitems/{0}";
        private string urlAdd = "https://localhost:7112/api/todoitems";
        private string urlDel = "https://localhost:7112/api/todoitems/{0}";
        private string urlUpdate = "https://localhost:7112/api/todoitems/{0}";

        private readonly IHttpClientFactory _clientFactory;
        private string Token { get; set; } = String.Empty;

        public TodoItemService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync(string token)
        {
            List<TodoItem> todos = new List<TodoItem>();
            try
            {
                if (String.IsNullOrEmpty(Token))
                {
                    Token = token;
                }
                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                var response = await client.GetAsync(urlGetAll);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    todos = JsonConvert.DeserializeObject<List<TodoItem>>(responseBody);
                }
                return todos.AsEnumerable();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        Task<TodoItem> ITodoItemService.GetByIdAsync(string token, int id)
        {
            throw new NotImplementedException();
        }

        Task<TodoItem> ITodoItemService.AddAsync(string token, AddTodoItem todo)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITodoItemService.DelAsync(string token, int id)
        {
            throw new NotImplementedException();
        }

        Task<TodoItem> ITodoItemService.UpdateAsync(string token, int Id, AddTodoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}
