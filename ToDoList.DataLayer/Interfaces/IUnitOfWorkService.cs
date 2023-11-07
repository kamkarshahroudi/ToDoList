using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataLayer.Interfaces
{
    public interface IUnitOfWorkService
    {
        /// <summary>
        /// Define interface for the classe UnitOfWorkServices
        /// </summary>
        /// <returns></returns>
        int Save();
        IToDoList toDoList { get; set; }
    }
}
