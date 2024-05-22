using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleApp.Classes.Statics
{
    public static class HelperStatic
    {
        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || char.IsLower(name[0]) || name.Length < 3 || name.Contains(" "))
                throw new ArgumentException("Invalid name format.");
        }

        public static void ValidateSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname) || char.IsLower(surname[0]) || surname.Length < 3 || surname.Contains(" "))
                throw new ArgumentException("Invalid surname format.");
        }

        public static void ValidateClassName(string className)
        {
            if (className.Length != 5 || !char.IsUpper(className[0]) || !char.IsUpper(className[1]) ||
                !char.IsDigit(className[2]) || !char.IsDigit(className[3]) || !char.IsDigit(className[4]))
                throw new ArgumentException("Invalid classroom name format.");
        }
    }
}
