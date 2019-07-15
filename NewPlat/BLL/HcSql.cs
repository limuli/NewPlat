using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.BLL
{
    class HcSql
    {
       private static HttpClient client;

        public HcSql()
        {
            this.GetClient();
        }

        public void GetClient()
        {
                var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
                client = httpClientFactory.CreateClient();                         
        }
        public async Task<string> PostSend(string requestUri , List<KeyValuePair<string, string>> param)
        {
            HttpContent qc = new FormUrlEncodedContent(param);
            using (var response = await client.PostAsync(requestUri, qc))
            {
                return await response.Content.ReadAsStringAsync();
            }                                  
        }  
    }
}
