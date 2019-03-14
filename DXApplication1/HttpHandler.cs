using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    partial class Form1
    {
        public async Task<string> Request(string orderName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var r = await client.GetAsync(new Uri("http://localhost:8000/getCarDestination?orderNumber=" + orderName)))
                    {
                        string result = await r.Content.ReadAsStringAsync();
                        AddInfoLog("HTTP请求成功-订单号:" + orderName + "-落格号：" + result);
                        return result;
                    }
                }
                catch (Exception e)
                {
                    AddErrorLog("HTTP请求失败-订单号-" + orderName + "-{" + e.Message + "}");
                    return "";
                }
            }
        }
    }
}
