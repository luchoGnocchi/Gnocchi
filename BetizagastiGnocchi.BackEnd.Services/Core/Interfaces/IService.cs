using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.Core.Interfaces
{
    public interface IService<TEntity> where TEntity : class, new()
    {
        TEntity Update(string token, TEntity item);
        bool Exist(params object[] keyValues);
        void DeleteById(string token, params object[] keyValues);
        void Add(string token, TEntity item);
        TEntity GetbyId(params object[] keyValues);
        ICollection<TEntity> GetAll();
    }
}
