using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Interfaces
{
    public interface ITaskRepository
    {
        Task CreateAsync (ToDoTask task);
        Task UpdateAsync(ToDoTask task);
        Task DeleteAsync(int id);
        Task<ToDoTask> GetByIdAsync(int id);
        Task<IEnumerable<ToDoTask>> GetAllAsync();

    }
}
