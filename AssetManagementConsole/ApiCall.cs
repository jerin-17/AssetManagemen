
using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using AssetManagementConsole;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AssetManagementConsole
{
    public class ApiCall<T> : IApiCall<T> where T : class
    {
        private readonly string endPoint;
        private readonly HttpClient client;

        public ApiCall(string ep)
        {
            endPoint = ep;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7075/");
        }
        public List<T> GetData()
        {
            var response = client.GetAsync(endPoint).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonConvert.DeserializeObject<List<T>>(responseContent);
                return getResponse;
            }
            else
            {
                return null;
            }
        }

        public T GetDataById(int id)
        {
            var response = client.GetAsync($"{endPoint}?id={id}").Result;
            try { 
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonConvert.DeserializeObject<T>(responseContent);
                return getResponse;
            }
            catch(Exception ex) 
            {
                return null;
            }
        }


        public int PostData(T data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(endPoint, content).Result;

            string responseContent1 = response.Content.ReadAsStringAsync().Result;
            try
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                int responseId = JsonConvert.DeserializeObject<int>(responseContent);
                return responseId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }


        }

        public List<int> PostData(List<T> data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(endPoint, content).Result;

            string responseContent1 = response.Content.ReadAsStringAsync().Result;
            try
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                List<int> responseId = JsonConvert.DeserializeObject<List<int>>(responseContent);
                return responseId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<int>();
            }


        }

        public void PatchData(T data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PatchAsync(endPoint, content).Result;
        }
    }
}
