using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace exercise_2.Classes
{
    public static class Api
    {
        static string backendUrlValue;
        static string backEndUrlName="EX1_URL";

        static Api(){
            backendUrlValue= Environment.GetEnvironmentVariable(backEndUrlName);
            Console.WriteLine("Using Back end Url {0}={1}",backEndUrlName,backendUrlValue);
        }
        public static List<string> Get(string endpoint)
        {
            
            
            
            using (HttpClient client = new HttpClient())
            {
                    client.BaseAddress = new Uri (backendUrlValue);
                    
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    
                    HttpResponseMessage response = client.GetAsync("/api/" + endpoint).Result;
                    
                    string stringData = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<string>>(stringData);
            }
        }
    }
}