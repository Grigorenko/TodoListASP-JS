using System.Collections.Generic;
using System.IO;

namespace TodoListASP_JS.Models
{
    public class Context
    {
        private string path = @"C:\Users\Vetal\Desktop\file.txt";

        public ICollection<string> GetList()
        {
            ICollection<string> list = new List<string>();

            using (StreamReader stream = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                while (stream.Peek() != -1)
                {
                    list.Add(stream.ReadLine());
                }
            }

            return list;
        }

        public void Add(string todo)
        {
            using (StreamWriter stream = new StreamWriter(new FileStream(path, FileMode.Append)))
            {
                stream.WriteLine("\n" + todo);
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

        public void Replace(ICollection<string> list)
        {
            using (StreamWriter stream = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                foreach (var item in list)
                {
                    stream.WriteLine(item);
                }
            }
        }
    }
}