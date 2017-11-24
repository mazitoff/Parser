using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class RefClass : ParentClass
    {
        static int _property;
        static int _var;

        static RefClass()
        {
            _property = 12;
            _var = 989;
        }

        public new int Property => _property;
        public int Var => _var;
    }
}
