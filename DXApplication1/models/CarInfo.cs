using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.models
{
    class CarInfo
    {
      

        public Guid CarInfoId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
