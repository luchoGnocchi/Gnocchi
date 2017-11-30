using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.Core.Generics
{
	public class GenericService<T> : IService<T> where T : class, new()
	{
		protected IRepository<T> _genericRepository;

		public GenericService(IRepository<T> genericRepository)
		{
			_genericRepository = genericRepository;
		}
		public virtual void Add( string token,T t)
		{
			_genericRepository.Insert(t);

		}

		public virtual void Delete(string token, params object[] keyValues)
		{
			_genericRepository.Delete(keyValues);

		}


		public virtual void DeleteById(string token, params object[] keyValues)
		{
			 
			
				_genericRepository.Delete(keyValues);

		}



		public virtual T GetbyId(params object[] keyValues)
		{
			return _genericRepository.GetByID(keyValues);
		}

		public virtual T Update( string token, T item)
		{
            //NO FUNCIONA ID EN UPDATE HARDCODEADA
			return _genericRepository.Update(item, 1);
		}

		public virtual ICollection<T> GetAll()
		{
			return _genericRepository.GetAll().ToList();
		}



		public virtual bool Exist(params object[] keyValues)
		{
			return _genericRepository.GetByID(keyValues) != null;
		}
	}
}
