using ReimbursementParkingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<int> Approve(T entity);
        Task<int> Reject(T entity);
        Task<T> GetById(int id);
        Task<Blob> GetFile(int id);
    }
}
