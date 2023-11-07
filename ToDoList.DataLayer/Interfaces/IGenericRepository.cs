using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataLayer.Model;

namespace ToDoList.DataLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Deffine interface for the classe Generic repository
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        IEnumerable<T> GetAll();
       
       
    }
}
