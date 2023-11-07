using AutoMapper;
using ToDoList.BusinessLayer.Model;
using ToDoList.DataLayer.Model;

namespace ToDoList.Configuration
{
    public class MappingConfiguration
    {
        /// <summary>
        /// Methode to convert ModelDto in BusinessLayer To model in DataLayer
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMaps()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ItemsToDoList, ItemsToDoListDto>().ReverseMap();              
            });
            return configuration;
        }
    }
}
