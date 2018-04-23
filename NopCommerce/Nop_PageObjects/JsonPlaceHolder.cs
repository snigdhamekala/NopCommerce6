using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NopCommerce.Nop_PageObjects
{
    public class JsonPlaceHolder
    {
        public static Boolean output;
        public async void fetchResultsFromPublicAPI(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            using (HttpContent content = response.Content)
            {
                //Here the response code should be 200 OK
                Assert.IsTrue(response.IsSuccessStatusCode);
                // ... Read the content.
                string result = await content.ReadAsStringAsync();
                if (result != null)
                    output = true;
            }
            
        }

        // Here we are validating the response to not null as we dont have any expected value to compare.

        public Boolean validateData()
        {
            if(output)
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }
    }
}
