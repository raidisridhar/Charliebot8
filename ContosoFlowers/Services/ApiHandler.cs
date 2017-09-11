using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System;

namespace ContosoFlowers.Services
{
    /// <summary>
    /// Responsible for constructing and issuing Http GET requests for certain API
    /// </summary>
    public sealed class ApiHandler : IApiHandler
    {
        //private readonly HttpClient client = new HttpClient();
        private  HttpClient client = new HttpClient();
        // public async Task<T> GetJsonAsync<T>(string url, IDictionary<string, string> requestParameters, IDictionary<string, string> headers) where T : class
        public string GetJsonAsync<T>(string url, IDictionary<string, string> requestParameters, IDictionary<string, string> headers) where T : class
        {
            try
            {
                string rawResponse = this.SendRequestAsync(url, requestParameters, headers);

                return rawResponse;
            }
            catch (Exception ex)
            {
                var exception = ex;

                return "Error";
            }
        }

        public string GetStringAsync(string url, IDictionary<string, string> requestParameters, IDictionary<string, string> headers)
        {
            return  this.SendRequestAsync(url, requestParameters, headers);
        }

        private  string SendRequestAsync(string url, IDictionary<string, string> requestParameters, IDictionary<string, string> headers)
        {
            this.client.DefaultRequestHeaders.Clear();

            string fullUrl = url;

            if (requestParameters != null)
            {
                var requestParams = "?";
                bool first = true;

                foreach (var elem in requestParameters)
                {
                    requestParams += (first == false ? "&" : string.Empty) + $"{elem.Key}={HttpUtility.UrlEncode(elem.Value)}";
                    first = false;
                }

                fullUrl += requestParams;
            }


            if (headers != null)
            {
                foreach (var header in headers)
                {
                    this.client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            try
            {
                return fullUrl;
                ////var response = await this.client.GetAsync(fullUrl);
                //HttpResponseMessage response = client.GetAsync(fullUrl).Result;
                //if (response != null)
                //{
                //    //var rawResponse = await response.Content.ReadAsStringAsync();
                //    var rawResponse =  response.Content.ReadAsStringAsync().Result;
                //    return rawResponse;
                //}
                //else
                //{
                //    return string.Empty;


                //}
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}