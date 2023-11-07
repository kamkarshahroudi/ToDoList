using Microsoft.EntityFrameworkCore.Query;
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
    public class ToDoListRepository : GenericRepository<ItemsToDoList>, IToDoList
    {
        /// <summary>
        /// Injection logger
        /// </summary>
        private readonly ILogger<ToDoListRepository> _logger;
        /// <summary>
        /// Create constructor 
        /// </summary>
        /// <param name="dbcontext"></param>
        /// <param name="logger"></param>
        public ToDoListRepository(DbContextApplication dbcontext, ILogger<ToDoListRepository> logger) : base(dbcontext, logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Methode for deleteing any items of to do list in database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(int id)
        {
            _logger.LogInformation($"{nameof(DeleteItem)} : Delete Item in database");
            try
            {
                
                _dbcontext.Remove(_dbcontext.ItemsToDoList.Where(x => x.Id == id).FirstOrDefault());
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(DeleteItem)} : Error For Delete item in database:  {ex.Message}");
                
            }
        }
        /// <summary>
        /// Edite any items of to do liste in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemsToDoList"></param>
        public void EditItems(int id, ItemsToDoList itemsToDoList)
        {
            _logger.LogInformation($"{nameof(EditItems)} : Edite To Do List in database");
            try
            {
                var editToDoList  = _dbcontext.ItemsToDoList.Find(id);
                editToDoList.ItemDescription = itemsToDoList.ItemDescription;
                editToDoList.ItemName = itemsToDoList.ItemName;
                editToDoList.ItemStatus = itemsToDoList.ItemStatus;
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(EditItems)} : Error For Editeing To Do List in in database:  {ex.Message}");
              
            }
        }

      
    }
}
