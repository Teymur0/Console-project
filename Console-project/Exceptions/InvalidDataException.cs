using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_project.Exceptions
{
    internal class InvalidDataException:Exception
    {

        public InvalidDataException(string err) : base(err) { }


    }
}
