using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.BusinessLayer.Model;
using ToDoList.BusinessLayer.Services;
using ToDoList.DataLayer.Model;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IServiceToDoListI _serviceToDoListI;
        private readonly ILogger<ToDoListController> _logger;
        private readonly DbContextApplication _dbContextApplication;

        public ToDoListController (IServiceToDoListI serviceToDoListI, ILogger<ToDoListController> logger, DbContextApplication dbContextApplication)
        {
            _logger = logger;
            _serviceToDoListI = serviceToDoListI;
            _dbContextApplication = dbContextApplication;
        }
        /// <summary>
        /// Entering the to do list items into the database (Creer un tache)
        /// </summary>
        /// <param name="itemsToDoList"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]
        public ActionResult SaveToDoList(ItemsToDoListDto itemsToDoList)
        {
            _logger.LogInformation($"{nameof(SaveToDoList)} : Save in DB");
            try
            {
               _serviceToDoListI.SaveToDoListInDB(itemsToDoList);

            }
            catch(Exception ex)
            {
                _logger.LogError($"{nameof(SaveToDoList)} : Error For Save in DB:  {ex.Message}");
            }
            return this.Ok();
        }
        /// <summary>
        /// Show all information to do list (Consulter la list des taches)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllToDoList")]
        public async Task<IActionResult> GetAllToDoList()
        {
            _logger.LogInformation($"{nameof(GetAllToDoList)} : Get All To Do List");
            try
            {
                
                var list = _serviceToDoListI.GetAllToDoList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetAllToDoList)} : Error For Get All To Do List:  {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Delete to do list (Supprimer une tache)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteToDoList")]
        public async Task DeleteToDoItem([FromQuery] int id)
        {
            _logger.LogInformation($"{nameof(DeleteToDoItem)} : Delete in DB");
            try
            {
                _serviceToDoListI.DeleteToDoList(id);
            }

            catch (Exception ex)
            {
                _logger.LogError($"{nameof(DeleteToDoItem)} : Error For Delete in DB:  {ex.Message}");

            }
        }
        /// <summary>
        /// Edite any Item (Completer une tache)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemsToDoListDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditeToDoList")]
        public async Task<IActionResult> EditeToDoItemModel(int id, ItemsToDoListDto  itemsToDoListDto)
        {
            if (id != itemsToDoListDto.Id)
            {
                return BadRequest();
            }

            _logger.LogInformation($"{nameof(EditeToDoItemModel)} : Edite in DB");

            try
            {
                _serviceToDoListI.EditeToDoList(id,itemsToDoListDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(EditeToDoItemModel)} : Error For edite in Db:  {ex.Message}");
            }

            return NoContent();
        }
    }
}
