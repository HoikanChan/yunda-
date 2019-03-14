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
        // 称重时间
        public string WeightTime { get; set; }
        // 扫描时间
        public string SacnTime { get; set; }
        // 落格时间
        public string ArrivalTime { get; set; }
        // 重量
        public string Weight { get; set; }
        // 来源
        public string From { get; set; }
        // 集包编号
        public string PackageNumber { get; set; }
        // 落格号
        public string CheckNumber { get; set; }
        // 目的站点
        public string To { get; set; }
        public override string ToString()
        {
            return "小车号：" + CarId+ " 订单号：" + OrderNumber + " 集包编号：" + PackageNumber + " 落格号：" + CheckNumber;
        }
    }
}
