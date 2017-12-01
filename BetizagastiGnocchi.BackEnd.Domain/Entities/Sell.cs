using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Domain.Entities
{
    public class Sell
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public long? Price { get; set; }
    }
}
