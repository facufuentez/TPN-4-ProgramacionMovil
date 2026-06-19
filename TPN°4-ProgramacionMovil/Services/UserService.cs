using System.Net.Http.Json;
using TPN_4_ProgramacionMovil.Models;

namespace TPN_4_ProgramacionMovil.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<User>>("users") ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuarios: {ex.Message}", ex);
            }
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<User>($"users/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario {id}: {ex.Message}", ex);
            }
        }

        public async Task<User?> CreateAsync(User user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("users", user);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<User>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear usuario: {ex.Message}", ex);
            }
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"users/{id}", user);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<User>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar usuario {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"users/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar usuario {id}: {ex.Message}", ex);
            }
        }
    }
}
