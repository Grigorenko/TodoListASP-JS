using System.Collections.Generic;
using System.Web.Http;

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
        public void Add(string todo)
        {
            context.Add(todo);
        }

        [HttpGet]
        public void Edit(string oldTodo, string newTodo)
        {
            context.Edit(oldTodo, newTodo);
        }

        [HttpGet]
        public void Delete(string todo)
        {
            context.Delete(todo);
        }

        [HttpGet]
        public void Replace(ICollection<string> list)
        {
            context.Replace(list);
        }
    }
}
