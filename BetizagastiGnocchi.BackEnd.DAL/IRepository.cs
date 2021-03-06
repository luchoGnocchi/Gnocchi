﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System.Linq.Expressions;

namespace BetizagastiGnocchi.BackEnd.DAL
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> Get(
				Expression<Func<TEntity, bool>> filter = null,
				Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
				string includeProperties = "");

		TEntity GetByID(params object[] keyValues);

		void Insert(TEntity entityToCreate);

        void Delete(params object[] keyValues);

        IQueryable<TEntity> GetAll();

        TEntity Update(TEntity entityToUpdate, params object[] keyValues);

    }
}
