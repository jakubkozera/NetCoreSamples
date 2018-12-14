using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models.Entities;

namespace DataAccess.Repositories
{
    public interface IValueRepository
    {
        Task<List<Value>> GetAll();
    }
}
