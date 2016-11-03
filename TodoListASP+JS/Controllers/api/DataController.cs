using System.Collections.Generic;
using System.Web.Http;
using TodoListASP_JS.Models;

namespace TodoListASP_JS.Controllers
{
    public class DataController : ApiController
    {
        Models.Context context;
        public DataController()
        {
            context = new Models.Context();
        }

        [HttpGet]
        public ICollection<string> GetList()
        {
            return context.GetList();
        }

        [HttpGet]
        public string GetById([FromUri] int id)
        {
            return context.GetById(id);
        }

        [HttpPost]
        public void Add([FromUri] string todo)
        {
            context.Add(todo);
        }

        [HttpPost]
        public void Edit([FromUri] string oldTodo, [FromUri] string newTodo)
        {
            context.Edit(oldTodo, newTodo);
        }

        [HttpGet]
        public void Delete([FromUri] string todo)
        {
            context.Delete(todo);
        }

        [HttpGet]
        public void Remove([FromUri] string todo, [FromUri] bool direction)
        {
            if (direction)//down
            {
                context.RemoveDown(todo);
            }
            else//up
            {
                context.RemoveUp(todo);
            }
        }

    }
}
