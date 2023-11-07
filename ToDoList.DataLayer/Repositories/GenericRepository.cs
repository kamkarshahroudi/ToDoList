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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Injection DbContex and Logger
        /// </summary>
        protected readonly DbContextApplication _dbcontext;
        private readonly ILogger<GenericRepository<T>> _logger;
        /// <summary>
        /// Create constructore
        /// </summary>
        /// <param name="dbcontext"></param>
        /// <param name="logger"></param>
        public GenericRepository(DbContextApplication dbcontext
             , ILogger<GenericRepository<T>> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }
        /// <summary>
        /// Methode save the information in database
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
        }
        /// <summary>
        /// Methode Get All information to do list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _dbcontext.Set<T>().ToList();
        }
    

       
        
    }
}
