using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriatlonCore.DependencyInjection;
using TriatlonLogic.Interfaces;

namespace TriatlonDataAccess.Repositories
{
	public abstract class BaseRepository<TEntity, TContext>
								where TEntity : class, IOid, new()
								where TContext : DbContext, new()
	{
		protected TContext _entities;
		public BaseRepository()
		{
			_entities = TDI.Resolve<TContext>();
		}

		public virtual IQueryable<TEntity> GetAll()
		{
			return GetDbSet();
		}

		public virtual TEntity Get(long oid)
		{
			return GetDbSet().Find(oid);
		}

		protected DbSet<TEntity> GetDbSet()
		{
			return _entities.Set<TEntity>();
		}

		public virtual Int64 Add(TEntity entity)
		{
			GetDbSet().Add(entity);
			Save();
			return GetOid(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			GetDbSet().Remove(entity);
			Save();
			return;
		}

		public virtual void AddRange(List<TEntity> entities)
		{
			GetDbSet().AddRange(entities);
			Save();
			return;
		}

		public virtual void Update(TEntity entity)
		{
			GetDbSet().Update(entity);
			Save();
			return;
		}

		public virtual void UpdateRange(List<TEntity> entities)
		{
			GetDbSet().UpdateRange(entities);
			Save();
			return;
		}

		public virtual void DeleteRange(List<TEntity> entities)
		{
			GetDbSet().RemoveRange(entities);
			Save();
			return;
		}

		public virtual List<TEntity> GetAllSkipTake(int skip, int take)
		{
			return GetDbSet().OrderBy(x => x.OID).Skip(skip).Take(take).ToList();
		}

		public void Save()
		{
			_entities.SaveChanges();
		}

		protected virtual long GetOid(TEntity entity)
		{
			if (entity is IOid)
				return ((IOid)entity).OID;
			return -1;
		}


	}
}
