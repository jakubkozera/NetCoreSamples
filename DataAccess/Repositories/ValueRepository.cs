using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ValueRepository : IValueRepository
    {
        private readonly AppDbContext _dbContext;

        public ValueRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Value>> GetAll()
        {
            var values = await _dbContext.Values.ToListAsync();
            return values;
        }
    }
}
