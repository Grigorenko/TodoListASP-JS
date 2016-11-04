using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace TodoListASP_JS.Models
{
    public class Context
    {
        private string path;
        public Context()
        {
            path = HostingEnvironment.MapPath("~/App_Data/file.txt");
        }

        public ICollection<string> GetList()
        {
            ICollection<string> list = new List<string>();

            try
            {
                using (StreamReader stream = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    while (stream.Peek() != -1)
                    {
                        list.Add(stream.ReadLine());
                    }
                }
            }
            catch (System.Exception)
            {
            }

            return list;
        }

        public string GetById(int id)
        {
            string result = "";
            System.Threading.Thread.Sleep(50);
            try
            {
                using (StreamReader stream = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    for (int i = 0; i < id; i++)
                    {
                        stream.ReadLine();
                    }
                    result = stream.ReadLine();
                }
            }
            catch (System.Exception)
            {
            }

            return result;
        }

        public void Add(string todo)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(new FileStream(path, FileMode.Append)))
                {
                    stream.WriteLine(todo);
                }
            }
            catch (System.Exception)
            {
            }
        }

        public void Edit(string oldTodo, string newTodo)
        {
            ICollection<string> list = new List<string>();

            using (StreamReader stream = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                while (stream.Peek() != -1)
                {
                    var temp = stream.ReadLine();

                    if (temp != oldTodo)
                    {
                        list.Add(temp);
                    }
                    else
                    {
                        list.Add(newTodo);
                    }
                }
            }
            Replace(list);
        }

        public void Delete(string todo)
        {
            ICollection<string> list = new List<string>();

            try
            {
                using (StreamReader stream = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    while (stream.Peek() != -1)
                    {
                        var temp = stream.ReadLine();

                        if (temp != todo)
                        {
                            list.Add(temp);
                        }
                    }
                }
                Replace(list);
            }
            catch (System.Exception)
            {
            }
        }

        public void RemoveDown(string todo)
        {
            List<string> list = (List<string>)GetList();

            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == todo)
                    {
                        list[i] = list[i + 1];
                        list[i + 1] = todo;
                        break;
                    }
                }
                Replace(list);
            }
            catch (System.Exception)
            {
            }
        }

        public void RemoveUp(string todo)
        {
            List<string> list = (List<string>)GetList();

            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == todo)
                    {
                        list[i] = list[i - 1];
                        list[i - 1] = todo;
                        break;
                    }
                }
                Replace(list);
            }
            catch (System.Exception)
            {
            }
        }

        private void Replace(ICollection<string> list)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    foreach (var item in list)
                    {
                        stream.WriteLine(item);
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }
    }
}