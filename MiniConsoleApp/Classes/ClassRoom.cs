using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniConsoleApp.Exceptions;
using MiniConsoleApp.Helper;

namespace MiniConsoleApp.Classes
{
    public class ClassRoom
    {
        private static int _idCounter = 1;
        private List<Student> _students;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public ClassRoomType Type { get; private set; }
        public int Limit { get; private set; }

        public ClassRoom(string name, ClassRoomType type)
        {
            Id = _idCounter++;
            Name = name;
            Type = type;
            _students = new List<Student>();

            if (type == ClassRoomType.BackEnd)
                Limit = 20;
            else if (type == ClassRoomType.FrontEnd)
                Limit = 15;
        }

        public void AddStudent(Student student)
        {
            if (_students.Count >= Limit)
                throw new InvalidOperationException("Classroom is full.");

            _students.Add(student);
        }

        public Student FindStudentById(int id)
        {
            foreach (var student in _students)
            {
                if (student.Id == id)
                    return student;
            }
            throw new StudentNotFoundException($"Student with ID {id} not found.");
        }

        public void DeleteStudentById(int id)
        {
            var student = FindStudentById(id);
            _students.Remove(student);
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(_students);
        }
    }
}
