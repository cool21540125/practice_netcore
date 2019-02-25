# 

- 2019/02/25
- [使用 ASP.NET Core MVC 建立 Web API](https://docs.microsoft.com/zh-tw/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio-code)


```powershell
> dotnet new webapi -o TodoApi
> cd TodoApi

# 到這 https://localhost:5001/api/values
# 看到 ["value1","value2"] ((不安全阿@@))
# dotnet dev-certs https --trust ((信任自我簽屬憑證))


> mkdir Models
# 1. 新增 Models/TodoItem.cs , 內容如下 ------
namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
# 內容如上 ----------------------------------

# 3. 新增 Models/TodoContext.cs , 內容如下 ---
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
# 內容如上 -------------------------------

# 4. 更新 Startup.cs
# 4-1 
using Microsoft.EntityFrameworkCore;

# 4-2 
using TodoApi.Models;

# 4-3 
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<TodoContext>(opt =>
        opt.UseInMemoryDatabase("TodoList"));
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
}

# 5. 建立 Controllers/TodoController.cs , 內容如下 ---
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
# 內容如上 -------------------------------
# GO ~~~ 
# https://localhost:5001/api/values
# https://localhost:5001/api/todo/1

# POST 方法
// POST: api/Todo
[HttpGet]
public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
{
    _context.TodoItems.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new TodoItem{ Id = item.Id }, item);
}

### 使用 jQuery
# 修改 Startup.cs
# 編輯 Configure...
    app.UseDefaultFiles();
    app.UseStaticFiles();
# 增加這兩個

# 建立 dir
> mkdir wwwroot
# 新增 wwwroot/index.html (編輯~~)
# 新增 wwwroot/site.js (編輯~~)

### 若要測試 html 則~~~
# 
```

