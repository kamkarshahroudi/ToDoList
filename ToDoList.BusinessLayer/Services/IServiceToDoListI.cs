using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BusinessLayer.Model;
using ToDoList.DataLayer.Model;

namespace ToDoList.BusinessLayer.Services
{
    public interface IServiceToDoListI
    {/// <summary>
    /// Definition interface for Services
    /// </summary>
    /// <param name="itemsToDoList"></param>
        void SaveToDoListInDB(ItemsToDoListDto itemsToDoList);
        List<ItemsToDoListDto> GetAllToDoList();
        void DeleteToDoList(int id);
        void EditeToDoList(int id, ItemsToDoListDto itemsToDoListDto);
    }
}
