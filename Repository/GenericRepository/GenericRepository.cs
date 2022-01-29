using DAW.Data;
using DAW.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DAWContext _context;
        protected readonly DbSet<TEntity> _table;

        //Dependency Injection (ne injecteaza o instanta de context)
        public GenericRepository(DAWContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        // Get all
        public async Task<List<TEntity>> GetAll()
        {
            // the select to the db 
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _table.AsNoTracking();

            // try not to use toList, count etc, before filtering the data
            // var entityList = _table.ToList();
            // var entityListFiltered = _table.Where(x => x.Id.ToString() != "");

            // better version; the data is filtered in the query 
            // select * from entity where Id is not null
            // var entitylistFiltered = _table.Where(x => x.Id.ToString() != "").ToList();
        }


        // Create
        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // Update

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        // Delete

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        // Find

        public TEntity FindById(object id)
        {
            return _table.Find(id);

        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);

            // another option
            // return await _table.FirstOrDefaultAsync(x=> x.Id.Equals(id));
        }


        // Save
        public bool Save()
        {
            //try
            //{
            return _context.SaveChanges() > 0;
            //}
            //catch(SqlException ex)
            //{
            //    Console.WriteLine(ex);
            //}

            // return false;
        }

        public async Task<bool> SaveAsync()
        {
            //try
            //{
            return await _context.SaveChangesAsync() > 0;
            //}
            //catch(SqlException ex)
            //{
            //    Console.WriteLine(ex);
            //}

            // return false;
        }

    }
}
