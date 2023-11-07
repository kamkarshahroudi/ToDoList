using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataLayer.Model
{
    public class ItemsToDoList
    {
        /// <summary>
        /// Define des objet model of To Do List
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define (?) to avid Nullable
        /// </summary>
        public string? ItemName { get; set; }


        public string? ItemDescription { get; set; }


        public bool ItemStatus { get; set; }
    }
}
