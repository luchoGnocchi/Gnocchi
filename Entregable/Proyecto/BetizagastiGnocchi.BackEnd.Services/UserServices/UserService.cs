using BetizagastiGnocchi.BackEnd.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System.Security.Cryptography;
using System.Linq.Expressions;
using System.Net;
using BetizagastiGnocchi.BackEnd.Common.Services.User;
using BetizagastiGnocchi.BackEnd.Common.Services.General;

namespace BetizagastiGnocchi.BackEnd.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService()
        {
            unitOfWork = new UnitOfWork();
        }

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public bool Exist(int idUsuario)
        {
            User user = unitOfWork.UserRepository.GetByID(idUsuario);
            return user != null;
        }

		public bool DeleteById(string token, int userId)
		{
			if(HasAccess(token, "User.DeleteById")) { 
			if (Exist(userId))
			{
				Expression<Func<User, bool>> filter = dto => dto.Rol.UType == Domain.Enum.UserType.Admin;
				var users = unitOfWork.UserRepository.Get(filter, null, string.Empty);
				if (users.Count() == 1)
					throw new UserIsTheOnlyAdminException(string.Format("No se puede borrar el usuario, porque es el único administrador del sistema.", userId));
				unitOfWork.UserRepository.Delete(userId);
				unitOfWork.Save();
				return true;
			}
				return false;
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));
	
		}

		public int CreateUser(string token, User user)
		{
			if (HasAccess(token, "User.CreateUser"))
			{
				Expression<Func<User, bool>> filter = dto => dto.UserName == user.UserName;
				var usuarios = unitOfWork.UserRepository.Get(filter, null, "");
				if (usuarios == null || usuarios.Count() == 0)
				{
					var passwordSalt = CreateSalt();
					var PasswordHash = EncryptPassword(user.Password, passwordSalt);
					user.Salt = passwordSalt;
					user.Password = PasswordHash;
					user.Token   = Guid.NewGuid();
					if (unitOfWork.UserRolRepository.GetByID(user.Rol_Id)==null)
						throw new RolNotFoundException(string.Format("No se encuentro el rol ", user.UserName));

					user.Rol = unitOfWork.UserRolRepository.GetByID(user.Rol_Id);
					unitOfWork.UserRepository.Insert(user);
					unitOfWork.Save();
					 
					return user.Id;
				}
				throw new UserAlreadyRegisteredException(string.Format("El nombre de usuario '{0}' ya está registrado.", user.UserName));
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}
		public ICollection<User> GetAll()
		{
			return unitOfWork.UserRepository.GetAll().ToList();
		}
		public User GetbyId(int userId)
		{
			User user = unitOfWork.UserRepository.GetByID(userId);
			
			if (user == null)
				throw new UserNotFoundException(string.Format("No se encontró el usuario con Id: {0}", userId));
			UserRol x = unitOfWork.UserRolRepository.GetByID(user.Rol_Id);
			user.Rol = x;
			return user;
		}
		public bool UpdateById(string token, int userId, User user)
        {
			if (HasAccess(token, "User.UpdateById"))
			{
				if (Exist(userId))
				{
					User userEntity = unitOfWork.UserRepository.GetByID(userId);
					if (!string.IsNullOrWhiteSpace(user.UserName))
						userEntity.UserName = user.UserName.Trim();

					if (!string.IsNullOrWhiteSpace(user.Password))
					{
						var passwordSalt = CreateSalt();
						var PasswordHash = EncryptPassword(user.Password.Trim(), passwordSalt);
						userEntity.Salt = passwordSalt;
						userEntity.Password = PasswordHash;
						if (unitOfWork.UserRolRepository.GetByID(user.Rol_Id) == null)
							throw new RolNotFoundException(string.Format("No se encuentro el rol ", user.UserName));

						user.Rol = unitOfWork.UserRolRepository.GetByID(user.Rol_Id);
					}
					if (user.Rol?.UType > 0)
						userEntity.Rol.UType = user.Rol.UType;
					unitOfWork.UserRepository.Update(userEntity, userEntity.Id);
					unitOfWork.Save();
					return true;
				}
				return false;
			}
			throw new ActionUnauthorizedException(string.Format("No está autorizado a acceder a esta acción"));

		}

		#region FuncionesAuxiliarioes para contreseña y token
		/// <summary>
		/// Crea random salt para encriptar la password del user
		/// </summary>
		/// <returns></returns>
		public static string CreateSalt()
        {
            var data = new byte[0x10];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        /// <summary>
        /// Encripto la contraseña usando el salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                var saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }

        /// <summary>
        /// Creo el token con Jwt con la informacion del user
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="dbUsuario"></param>
        /// <returns></returns>
        private static string CreateToken(User user, out object dbUsuario)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expiry = Math.Round((DateTime.UtcNow.AddHours(2) - unixEpoch).TotalSeconds);
            var issuedAt = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            var notBefore = Math.Round((DateTime.UtcNow.AddMonths(6) - unixEpoch).TotalSeconds);

            var payload = new Dictionary<string, object>
            {
                {"username", user.UserName},
                {"idUser", user.Id},
                {"type", user.Rol?.UType ?? Domain.Enum.UserType.Invited },
                {"nbf", notBefore},
                {"iat", issuedAt},
                {"exp", expiry}
            };

            var token = "";//JsonWebToken.Encode(payload, apikey, JwtHashAlgorithm.HS256);

            dbUsuario = new User();
            return token;
        }

		public bool HasAccess(string token, string actionName)
		{
			var user = unitOfWork.UserRepository.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault();			
			
			return user?.Rol?.ActionOperations?.Any(a => a.Name.TrimEnd() == actionName.TrimEnd()) == true ? true: throw new ActionUnauthorizedException("No está autorizado a acceder a esta acción") 
                ?? throw new ActionUnauthorizedException("No está autorizado a acceder a esta acción"); 
		}

		public string Login(string userName, string password)
		{
			Expression<Func<User, bool>> filter = dto => dto.UserName == userName;
			var usuarios = unitOfWork.UserRepository.Get(filter, null, "");
			if (usuarios != null && usuarios.Count()>0) 
			{
				var usuarioExistente = usuarios.FirstOrDefault();
				var loginSuccess = string.Equals(EncryptPassword(password, usuarioExistente.Salt),
							usuarioExistente.Password);
				if (loginSuccess) 
				{
					return usuarioExistente.Token.ToString();
				}
				throw new WrongPasswordException("Contraseña Erronea");
			}
			throw new UserNotFoundException("Usuario no encontrado");
		}
		#endregion
	}
}

