using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ParentClass Cl = new ParentClass();
            Console.WriteLine(Cl.Property);

            RefClass Cl01 = new RefClass();
            Console.WriteLine(Cl01.Property);

            ParentClass Cl02 = new RefClass();
            Console.WriteLine(Cl02.Property);
            Cl02 = (RefClass)Cl02;
            Console.WriteLine(Cl02.Property);
            Console.WriteLine(Cl02.Property);

            RefClass Cl04;
            Cl04 = new RefClass();
            Console.WriteLine(Cl04.Property);
            Console.WriteLine(Cl04.Var);

            Console.ReadKey();
        }
    }
}
