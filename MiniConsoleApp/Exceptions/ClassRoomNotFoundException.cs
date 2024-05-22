using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleApp.Exceptions
{
    public class ClassRoomNotFoundException : Exception
    {
        public ClassRoomNotFoundException(string message) : base(message) { }
    }
}
