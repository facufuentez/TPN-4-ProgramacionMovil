using System.Net.Http.Json;
using TPN_4_ProgramacionMovil.Models;

namespace TPN_4_ProgramacionMovil.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Product>>("products") ?? [];
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos: {ex.Message}", ex);
            }
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Product>($"products/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener producto {id}: {ex.Message}", ex);
            }
        }

        public async Task<Product?> CreateAsync(Product product)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("products", product);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Product>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear producto: {ex.Message}", ex);
            }
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"products/{id}", product);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Product>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar producto {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"products/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto {id}: {ex.Message}", ex);
            }
        }
    }
}
