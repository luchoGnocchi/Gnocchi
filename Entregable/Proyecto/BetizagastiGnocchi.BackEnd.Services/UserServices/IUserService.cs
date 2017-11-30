using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BetizagastiGnocchi.BackEnd.Services.UserService
{
    public interface IUserService 
    {
        bool UpdateById(string token,int userId, User user);
        bool Exist(int userId);
        bool DeleteById(string token,int v);
        int CreateUser(string token, User user);
        User GetbyId(int v);
		string Login(string user, string password);
		bool HasAccess(string token, string actionName);
		ICollection<User> GetAll();

	}
}