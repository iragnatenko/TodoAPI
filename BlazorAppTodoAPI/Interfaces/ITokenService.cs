using BlazorAppTodoAPI.Models;

namespace BlazorAppTodoAPI.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GetTokenAsync(TokenRequest tokenReq);

    }
}
