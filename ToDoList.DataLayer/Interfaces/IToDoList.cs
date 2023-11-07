using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataLayer.Model;

namespace ToDoList.DataLayer.Interfaces
{
    public interface IToDoList:IGenericRepository<ItemsToDoList>
    {
        
      /// <summary>
      /// define interface for the classe ToDoListRepository
      /// </summary>
      /// <param name="id"></param>
      /// <param name="itemsToDoList"></param>
        void EditItems(int id, ItemsToDoList itemsToDoList);
        void DeleteItem(int id);

    }
}
