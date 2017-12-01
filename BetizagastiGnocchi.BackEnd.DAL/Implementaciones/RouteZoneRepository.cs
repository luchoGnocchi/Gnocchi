using BetizagastiGnocchi.BackEnd.DAL.Interfaces;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.DAL.Implementaciones
{
 
    public class RouteZoneRepository : GenericRepository<RouteZone>, IRouteZoneRepository
    {
        public RouteZoneRepository(DbContext context) : base(context)
        {
        }
    }
}
