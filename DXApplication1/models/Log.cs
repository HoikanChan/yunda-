using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.models
{
    public class Log
    {
        public Guid Id { get; set; }
        public LogType Type { get; set; }
        public string Content { get; set; }
        public string CarId { get; set; }
        public string Created { get; set; }
    }
    public enum LogType
    {
        success,
        waring,
        error
    }
}
