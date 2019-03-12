using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.models
{
    public class Car
    {
        public Guid Id { get; set; }
        // 小车Id
        public string CarId { get; set; }
        // 订单号
        public string OrderNumber { get; set; }
        // 扫描时间
        public string SacnTime { get; set; }
        // 落格时间
        public string ArrivalTime { get; set; }
        // 重量
        public int Weight { get; set; }
        // 来源
        public string From { get; set; }
        // 集包编号
        public string PackageNumber { get; set; }
        // 落格号
        public string CheckNumber { get; set; }
        // 目的站点
        public string To { get; set; }
    }
}
