using System;
using System.ComponentModel.DataAnnotations;

namespace DXApplication1.models
{
    class PackageGridMapping
    {
        // 格口号
        [Key]
        public string CheckId { get; set; }
        // 目标站点号
        public string GoalNumber { get; set; }
        // 集包号
        public string PackageNumber { get; set; }

    }
}
