using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using System.Linq.Expressions;
using System.Net;

using BetizagastiGnocchi.BackEnd.Common.Services.General;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using BetizagastiGnocchi.BackEnd.Services.Core.Generics;
using BetizagastiGnocchi.BackEnd.Common.Services.Vehicle;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;

namespace BetizagastiGnocchi.BackEnd.Services.RouteZoneServices
{
	public class RouteZoneService : GenericService<RouteZone>, IRouteZoneService
    {
		
		private readonly IUserService userService;
		private readonly IRepository<RouteZone> genericRepository;
 
		public RouteZoneService(IRepository<RouteZone> genericRepository,  IUserService userService):base(genericRepository)
		{
			this.genericRepository = genericRepository;
		 
			this.userService = userService;
		}
	
		 
	 
	}
}
