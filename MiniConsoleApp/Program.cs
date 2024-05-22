using MiniConsoleApp.Classes;
using MiniConsoleApp.Classes.Statics;
using MiniConsoleApp.Exceptions;
using MiniConsoleApp.Helper;

namespace MiniConsoleApp
{
    public class Program
    {
        static List<ClassRoom> classrooms = new List<ClassRoom>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Classroom yarat");
                Console.WriteLine("2. Student yarat");
                Console.WriteLine("3. Butun Telebeleri ekrana cixart");
                Console.WriteLine("4. Secilmis sinifdeki telebeleri ekrana cixart");
                Console.WriteLine("5. Telebe sil");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateClassroom();
                        break;
                    case 2:
                        CreateStudent();
                        break;
                    case 3:
                        DisplayAllStudents();
                        break;
                    case 4:
                        DisplayClassroomStudents();
                        break;
                    case 5:
                        DeleteStudent();
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim, yenidən cəhd edin.");
                        break;
                }
            }
        }

        static void CreateClassroom()
        {
            try
            {
                Console.Write("Sinif adini daxil edin: ");
                string name = Console.ReadLine();
                HelperStatic.ValidateName(name);

                Console.Write("Sinif növünü seçin (1-Backend, 2-FrontEnd): ");
                int typeChoice = int.Parse(Console.ReadLine());
                ClassRoomType type = (typeChoice == 1) ? ClassRoomType.BackEnd : ClassRoomType.FrontEnd;

                classrooms.Add(new ClassRoom(name, type));
                Console.WriteLine("Sinif uğurla yaradıldı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta: {ex.Message}");
            }
        }

        static void CreateStudent()
        {
            try
            {
                if (classrooms.Count == 0)
                    throw new ClassRoomNotFoundException("Heç bir sinif yoxdur.");

                Console.Write("Telebenin adini daxil edin: ");
                string name = Console.ReadLine();
                HelperStatic.ValidateName(name);

                Console.Write("Telebenin soyadini daxil edin: ");
                string surname = Console.ReadLine();
                HelperStatic.ValidateSurname(surname);

                Console.Write("Telebenin sinif ID'sini daxil edin: ");
                int classId = int.Parse(Console.ReadLine());
                ClassRoom classroom = classrooms.Find(c => c.Id == classId);

                if (classroom == null)
                    throw new ClassRoomNotFoundException("Verilmiş ID'li sinif tapılmadı.");

                classroom.AddStudent(new Student(name, surname));
                Console.WriteLine("Telebe uğurla yaradıldı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta: {ex.Message}");
            }
        }

        static void DisplayAllStudents()
        {
            if (classrooms.Count == 0)
            {
                Console.WriteLine("Heç bir sinif yoxdur.");
                return;
            }

            foreach (var classroom in classrooms)
            {
                Console.WriteLine($"Sinif: {classroom.Name}");
                foreach (var student in classroom.GetAllStudents())
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
                }
            }
        }

        static void DisplayClassroomStudents()
        {
            try
            {
                Console.Write("Sinif ID'sini daxil edin: ");
                int classId = int.Parse(Console.ReadLine());
                ClassRoom classroom = classrooms.Find(c => c.Id == classId);

                if (classroom == null)
                    throw new ClassRoomNotFoundException("Verilmiş ID'li sinif tapılmadı.");

                Console.WriteLine($"Sinif: {classroom.Name}");
                foreach (var student in classroom.GetAllStudents())
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta: {ex.Message}");
            }
        }

        static void DeleteStudent()
        {
            try
            {
                Console.Write("Sinif ID'sini daxil edin: ");
                int classId = int.Parse(Console.ReadLine());
                ClassRoom classroom = classrooms.Find(c => c.Id == classId);

                if (classroom == null)
                    throw new ClassRoomNotFoundException("Verilmiş ID'li sinif tapılmadı.");

                Console.Write("Telebe ID'sini daxil edin: ");
                int studentId = int.Parse(Console.ReadLine());

                classroom.DeleteStudentById(studentId);
                Console.WriteLine("Telebe uğurla silindi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta: {ex.Message}");
            }
        }
    }
}
