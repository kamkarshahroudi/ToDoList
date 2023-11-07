using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataLayer.Interfaces;
using ToDoList.DataLayer.Model;

namespace ToDoList.DataLayer.Repositories
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        /// <summary>
        /// Injection DbContext
        /// </summary>
        private readonly DbContextApplication _dbContext;
        public IToDoList toDoList { get; set; }
        public UnitOfWorkService(DbContextApplication dbContext, IToDoList  toDoListRepository)
        {
            _dbContext = dbContext;
            toDoList = toDoListRepository;
           
        }

        public int Save()
        {         
                return _dbContext.SaveChanges();          
        }
    }
}
