using System.Text;
using BlazorAppTodoAPI.Interfaces;
using BlazorAppTodoAPI.Models;
using Newtonsoft.Json;

namespace BlazorAppTodoAPI.Services
{
    public class TokenService : ITokenService
    {
        private const string urlGetToken = "https://localhost:7112/api/token";

        private readonly IHttpClientFactory _clientFactory;

        public TokenService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetTokenAsync(TokenRequest tokenReq)
        {
            var json = JsonConvert.SerializeObject(tokenReq);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string token = "";
            try
            {
                var client = _clientFactory.CreateClient();
                var response = await client.PostAsJsonAsync<TokenRequest>(urlGetToken, tokenReq);
                if (response.IsSuccessStatusCode)
                {
                    token = await response.Content.ReadAsStringAsync();
                    return token;
                }
                return "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
