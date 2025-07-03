using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EMS.Repositories.Interfaces.IGenericRepo;

namespace EMS.Repositories.Implimentations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _Context;

        public GenericRepo(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task Edit(T model)
        {
            _Context.Set<T>().Update(model);
            await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await _Context.Set<T>().ToListAsync();
            return list;
        }

        public async Task<T> GetById(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public async Task RemoveData(T model)
        {
            _Context.Set<T>().Remove(model);
            await _Context.SaveChangesAsync();
        }

        public async Task Save(T model)
        {
            await _Context.Set<T>().AddAsync(model);
            await _Context.SaveChangesAsync();
        }
    }
}
