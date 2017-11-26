using autentykacja_zadanie.ApiConsumer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace autentykacja_zadanie.ApiConsumer
{
    public class Client
    {
        private HttpClient _client;
        private HttpResponseMessage _httpResponse;
        private const string Url = "http://localhost:54450/api/Performances";
        private const string UrlEmail = "http://localhost:54450/api/EmailForm";
        private string _json;

        public object JsonConver { get; private set; }

        public Client()
        {
            _client = new HttpClient();            
        }

        public async Task<List<Performance>> GetAll()
        {
            _httpResponse = await _client.GetAsync(Url);
            _json = _httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Performance>>(_json);
        }

        public async Task<HttpStatusCode> SetPerformance(Performance performance)
        {
            _httpResponse = await _client.PostAsJsonAsync(Url, performance);
            return _httpResponse.StatusCode;
        }
        public async Task<HttpStatusCode> SendEmail(EmailApiModel emailModel)
        {
            _httpResponse = await _client.PostAsJsonAsync(UrlEmail, emailModel);
            return _httpResponse.StatusCode;
        }
    }
}