using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.LogServices
{
    public class LogDTO
    {        
        public string Date { get; set; }
        public string Type { get; set; }
        public string User { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
    }
}
