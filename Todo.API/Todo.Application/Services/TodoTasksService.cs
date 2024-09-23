using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Infrastructure.Interfaces;
using Todo.Infrastructure.Repositories;

namespace Todo.Application.Services
{
    public class TodoTasksService : ITodoTasksService
    {
        private readonly ITaskRepository _taskRepository;
        public TodoTasksService(ITaskRepository taskRepository) { 
        _taskRepository = taskRepository;
        }
        public Task CreateAsync(ToDoTask task)
        {
            try
            {
                if(task == null)
                {
                  throw new ArgumentNullException(nameof(task), "Task cannot be null.");
                }
                else
                {
                    return _taskRepository.CreateAsync(task);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public Task DeleteAsync(int id)
        {
            try
            {
                return _taskRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<IEnumerable<ToDoTask>> GetAllAsync()
        {
           try
            {
                return _taskRepository.GetAllAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<ToDoTask> GetByIdAsync(int id)
        {
            try
            {
                return _taskRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task UpdateAsync(ToDoTask task)
        {
            try
            {
                if (task == null)
                {
                    throw new ArgumentNullException(nameof(task), "Task cannot be null.");
                }
                else
                {
                    return _taskRepository.UpdateAsync(task);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
