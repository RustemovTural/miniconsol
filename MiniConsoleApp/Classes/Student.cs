using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleApp.Classes
{
    public class Student
    {
        private static int _Id;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Student(string name, string surname)
        {
            Id = ++_Id;
            Name = name;
            Surname = surname;
        }
    }

}
