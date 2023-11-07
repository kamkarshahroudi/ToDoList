using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataLayer.Model
{
    public class DbContextApplication : DbContext
    {/// <summary>
    /// Define DbContext
    /// </summary>
    /// <param name="options"></param>
        public DbContextApplication(DbContextOptions<DbContextApplication> options)
    : base(options)
        {
        }
        public DbSet<ItemsToDoList> ItemsToDoList { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
  
}
