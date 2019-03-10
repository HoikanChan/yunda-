using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class HttpHandler
    {
        async public static Task<string> Request(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}
