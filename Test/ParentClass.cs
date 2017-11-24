using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class ParentClass
    {
        static int _property;

        static ParentClass()
        {
            _property = 11;
        }

        public int Property => _property;
    }
}
