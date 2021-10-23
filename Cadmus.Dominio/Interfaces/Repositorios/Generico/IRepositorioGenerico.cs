using Cadmus.Dominio.Entidades.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioGenerico<TEntity, TId>
         where TEntity : Entity<TEntity, TId>
         where TId : struct
    {
        void Add(TEntity entity);
        TEntity AddWithReturn(TEntity entity);
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
        void Disposes();
        TEntity GetById(TId id);
        ValueTask<TEntity> GetByIdAsync(TId id);
        bool Commit();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
