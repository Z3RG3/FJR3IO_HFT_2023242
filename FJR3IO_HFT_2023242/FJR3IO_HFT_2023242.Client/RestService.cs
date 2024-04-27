using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FJR3IO_HFT_2023242.Client
{
    public class RestService
    {
        private readonly HttpClient client;

        public RestService(string baseUrl, string pingableEndpoint = "swagger")
        {
            bool isOk = false;
            do
            {
                isOk = Ping(baseUrl + pingableEndpoint);
            } while (!isOk);

            client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private bool Ping(string url)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<T>> Get<T>(string endpoint)
        {
            var items = new List<T>();
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadAsAsync<List<T>>();
            }
            else
            {
                var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
                throw new ArgumentException(error.Msg);
            }
            return items;
        }

        public async Task<T> GetSingle<T>(string endpoint)
        {
            var item = default(T);
            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<T>();
            }
            else
            {
                var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public async Task<T> Get<T>(int id, string endpoint)
        {
            var item = default(T);
            var response = await client.GetAsync(endpoint + "/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<T>();
            }
            else
            {
                var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
                throw new ArgumentException(error.Msg);
            }
            return item;
        }

        public async Task Post<T>(T item, string endpoint)
        {
            var response = await client.PostAsJsonAsync(endpoint, item);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
                throw new ArgumentException(error.Msg);
            }
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id, string endpoint)
        {
            var response = await client.DeleteAsync(endpoint + "/" + id.ToString());
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
                throw new ArgumentException(error.Msg);
            }
            response.EnsureSuccessStatusCode();
        }

        public async Task Put<T>(T item, string endpoint)
        {
            var response = await client.PutAsJsonAsync(endpoint, item);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
                throw new ArgumentException(error.Msg);
            }
            response.EnsureSuccessStatusCode();
        }
    }

    public class RestExceptionInfo
    {
        public string Msg { get; set; }
    }
}
