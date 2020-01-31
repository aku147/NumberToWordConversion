using FE_WebApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FE_WebApp.Implementation
{
    public class ServiceAccess : IServiceAccess
    {
        public ILogger _logger { get; set; }
        private static readonly object threadlock = new object();
        private static volatile HttpClient _httpClient;    
        
        public ServiceAccess(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///  Gives the instance of singleton httpclient so that no new httpclient get created for different request
        /// </summary>
        /// <returns></returns>
        public static HttpClient GetHttpClient()
        {
            try
            {
                if (_httpClient == null)
                {
                    lock (threadlock)
                    {
                        if (_httpClient == null)
                        {
                            _httpClient = new HttpClient();
                            _httpClient.Timeout = TimeSpan.FromSeconds(30);
                            return _httpClient;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _httpClient;
        }       

        /// <summary>
        /// Post the data to an API
        /// </summary>
        /// <typeparam name="T">Type of Response Object that is expected</typeparam>
        /// <typeparam name="M">Type Request Object that needs to be posted</typeparam>
        /// <param name="url">URL for the API where data needs to be posted</param>
        /// <param name="request">Request object that needs to be posted</param>
        /// <returns>Task of type of expected response</returns>
        public async Task<T> PostAsync<T,M>(string url, M request)
        {
            try
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url);

                var jsonString = JsonConvert.SerializeObject(request);
                httpRequest.Content = new StringContent(Convert.ToString(jsonString), Encoding.UTF8, "application/json");

                //Sending data to API
                HttpResponseMessage response = await GetHttpClient().SendAsync(httpRequest);
                
                if (response.IsSuccessStatusCode)
                {
                    string responseString = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                    var res = JsonConvert.DeserializeObject<T>(responseString);
                    return res;
                }
                else
                {
                    _logger.Debug("Call failed to API URL " + url);
                }
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }
            return default(T);
        }        
    }
}