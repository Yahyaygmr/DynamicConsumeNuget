using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DynamicConsume
{
    public class Consume<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Consume(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<T>> GetListAsync(string link)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{link}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<T>>(jsonData);
                return values;
            }
            return new List<T>();
        }
        public async Task<T> GetByIdAsync(string link, int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{link}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<T>(jsonData);
                return values;
            }
            return null;
        }
        public async Task<List<T>> GetListByIdAsync(string link, int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{link}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<T>>(jsonData);
                return values;
            }
            return new List<T>();
        }
        public async Task<int> PostAsync(string link, object modelClass)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(modelClass);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync($"{link}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }
        public async Task<int> PutAsync(string link, object modelClass)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(modelClass);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"{link}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }
        public async Task<int> DeleteAsync(string link, int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"{link}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }
    }
    
    public class Consume
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Consume(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> GetStringAsync(string link)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{link}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var stringData = await responseMessage.Content.ReadAsStringAsync();
                return stringData;
            }
            return "Bir Hata Oluştu";
        }
        public async Task<int> GetIntAsync(string link)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{link}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var intData = await responseMessage.Content.ReadAsStringAsync();
                return int.Parse(intData);
            }
            throw new HttpRequestException("Bir Hata Oluştu: " + responseMessage.ReasonPhrase);
        }
    }
}
