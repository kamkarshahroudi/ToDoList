using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoList.BusinessLayer.Model;
using ToDoList.DataLayer.Interfaces;
using ToDoList.DataLayer.Model;

namespace ToDoList.BusinessLayer.Services
{
    public class ServiceToDoListI : IServiceToDoListI
    {
    /// <summary>
    /// Injection in Classes services
    /// </summary>
        private readonly IUnitOfWorkService _unitOfWork;
        private readonly ILogger<ServiceToDoListI> _logger;
        private readonly DbContextApplication _dbContextApplication;
        private readonly IMapper _mapper;
        private readonly IToDoList _toDoListRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
        /// <param name="dbContextApplication"></param>
        /// <param name="mapper"></param>
        /// <param name="toDoListRepository"></param>
        public ServiceToDoListI(IUnitOfWorkService unitOfWork, 
            ILogger<ServiceToDoListI> logger, 
            DbContextApplication dbContextApplication, 
            IMapper mapper,
            IToDoList toDoListRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _dbContextApplication = dbContextApplication;
            _mapper = mapper;
            _toDoListRepository = toDoListRepository;
        }
        /// <summary>
        /// Methode for Save information to do listr in DataBase
        /// </summary>
        /// <param name="itemsToDoListDto"></param>
        public void SaveToDoListInDB(ItemsToDoListDto itemsToDoListDto)
        {
            _logger.LogInformation($"{nameof(SaveToDoListInDB)} : Save Data in database");
            try
            {
                _unitOfWork.toDoList.Add(_mapper.Map<ItemsToDoList>(itemsToDoListDto));
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(SaveToDoListInDB)} : Error For Saving Data in database:  {ex.Message}");
                
            }
        }
        /// <summary>
        /// methode Get All information To Do List
        /// </summary>
        /// <returns></returns>
        public List<ItemsToDoListDto> GetAllToDoList()
        {
            _logger.LogInformation($"{nameof(GetAllToDoList)} : Get All To Do List");
            try
            {
                return _mapper.Map<List<ItemsToDoListDto>>(_unitOfWork.toDoList.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetAllToDoList)} : Error For Get All To Do List:  {ex.Message}");
                throw ;
            }
        }
        /// <summary>
        /// Methode for Deleteing any items in DataBase
        /// </summary>
        /// <param name="id"></param>
        public void DeleteToDoList(int id)
        {
            _logger.LogInformation($"{nameof(DeleteToDoList)} : Delete To Do List in DB");
            try
            {
                _toDoListRepository.DeleteItem(id);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(DeleteToDoList)} : Error For Delete To Do List in DB:  {ex.Message}");

            }
        }
        /// <summary>
        /// Edite any item to do liste on DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemsToDoListDto"></param>
        public void EditeToDoList(int id, ItemsToDoListDto itemsToDoListDto)
        {
            _logger.LogInformation($"{nameof(EditeToDoList)} : Edite To Do List in DB");
            try
            {
                _toDoListRepository.EditItems(id,_mapper.Map<ItemsToDoList>(itemsToDoListDto));
            _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(EditeToDoList)} : Error For Edite To Do List in DB:  {ex.Message}");

            }
        }
    }
}
