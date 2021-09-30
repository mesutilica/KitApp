using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KitApp.WebUI.ApiServices
{
    public class AppUserApiService
    {
        private readonly HttpClient _httpClient;
        public AppUserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
