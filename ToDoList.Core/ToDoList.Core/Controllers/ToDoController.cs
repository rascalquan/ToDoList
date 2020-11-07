using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using ToDoList.Core.Models;
using ToDoList.Core.Repository;

namespace ToDoList.Core.Controllers
{
    /// <summary>
    /// 待办
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        readonly ILogger<ToDoController> _logger;
        readonly ToDoContext _todoContext;
        public ToDoController(ILogger<ToDoController> logger,ToDoContext toDoContext)
        {
            _logger = logger;
            _todoContext = toDoContext;
        }

        /// <summary>
        /// 获取所有待办事项
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            List<ToDoItem> list = await _todoContext.ToDoItems.ToListAsync();
            return Ok(new ResponseModel() { Code = (int)ErrorCode.Success, Message = "", Data = list });
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(ToDoItem item)
        {
            if (item == null)
                return Ok(new ResponseModel() { Code = (int)ErrorCode.InvalidParameter, Message = "todoitem 不能为空" });

            await _todoContext.ToDoItems.AddAsync(item);
            await _todoContext.SaveChangesAsync();
            return Ok(new ResponseModel { Code = (int)ErrorCode.Success });
        }
    }
}
