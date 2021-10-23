using Cadmus.Dominio.Entidades.Base;
using Cadmus.Dominio.Interfaces.Repositorios;
using Cadmus.Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadmus.Infra.Repositorios.Generico
{
    public class RepositorioGenerico<TEntity, TId> : IRepositorioGenerico<TEntity, TId>
        where TId : struct
        where TEntity : Entity<TEntity, TId>
    {
        protected SqlContext Db { get; private set; }
        protected DbSet<TEntity> DbSet { get; }

        public RepositorioGenerico(SqlContext context)
        {
            Db = context ?? throw new ArgumentException("Falha ao inicializar o repositório.Contexto inválido.");
            DbSet = Db.Set<TEntity>();
        }

        public void Disposes()
        {
            Db.Dispose();
        }

        public virtual void Add(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Added;
            DbSet.Add(entity);
        }

        public virtual TEntity AddWithReturn(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Added;
            DbSet.Add(entity);
            Db.Commit();
            return entity;
        }

        public virtual ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Added;
            return Db.AddAsync(entity);
        }

        public virtual TEntity GetById(TId id)
        {
            return DbSet.Find(id);
        }
        public virtual ValueTask<TEntity> GetByIdAsync(TId id)
        {
            return DbSet.FindAsync(id);
        }

        public bool Commit()
        {
            return Db.Commit();
        }

        public void Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

    }
}
