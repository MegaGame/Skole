using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryT3;

namespace ConsoleAppT3DllPathTest
{
    class PTProgram
    {
        DLLTests dt = new DLLTests();
        MyMath mm = new MyMath();
        static void Main(string[] args)
        {
            PTProgram p = new PTProgram();
            p.run();
        }
        public void run()
        {
            Math();
        }
        public void Cat()
        {

            Console.WriteLine(dt.liv.ToString());

            Console.ReadLine();

            Console.WriteLine(dt.CatLives(5));

            Console.ReadLine();
        }
        public void Math()
        {
            Console.WriteLine("Skriv et tal ");
            int a;
            Int32.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("Skriv et tal ");
            int b;
            Int32.TryParse(Console.ReadLine(), out b);
            Console.WriteLine(mm.Sum(a, b).ToString());
            Console.ReadLine();
        }
    }
}
