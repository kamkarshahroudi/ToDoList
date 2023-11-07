using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataLayer.Model;

namespace ToDoList.DataLayer.Configuration
{
    public class ToDoListConfiguration : IEntityTypeConfiguration<ItemsToDoList>
    {
        /// <summary>
        /// Variable definition settings to creat in database
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemsToDoList> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.ItemName).HasMaxLength(250);
            builder.Property(b => b.ItemDescription).HasMaxLength(5000);
           
        }
    }
}
