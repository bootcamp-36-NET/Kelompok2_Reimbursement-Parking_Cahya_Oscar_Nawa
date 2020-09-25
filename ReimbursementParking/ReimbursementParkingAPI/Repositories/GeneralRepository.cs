using Microsoft.EntityFrameworkCore;
using ReimbursementParkingAPI.Bases;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Repositories
{
    public class GeneralRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, BaseModel
        where TContext : MyContext
    {
        private readonly MyContext _context;
        public GeneralRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public async Task<TEntity> GetById(int id)
        {
            var data = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (!data.Equals(0))
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Approve(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Reject(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<byte[]> GetFile(int blobId)
        {
            var content = await _context.Blobs.Where(q => q.Id == blobId).Select(q => q.Content).FirstOrDefaultAsync();
            return content;
        }
    }
}
