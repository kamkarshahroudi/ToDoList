using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BusinessLayer.Model
{
    /// <summary>
    /// Create obj Dto
    /// </summary>
    public class ItemsToDoListDto
    {
        public int Id { get; set; }


        public string? ItemName { get; set; }


        public string? ItemDescription { get; set; }


        public bool ItemStatus { get; set; }
    }
}
