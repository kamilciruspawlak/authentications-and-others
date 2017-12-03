using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Suko podaj liczbe!:");
            int x = int.Parse(Console.ReadLine());
           
            for (int i = 2; i <=x; i++)
            {
                if (x == i)
                {
                    Console.WriteLine("Pierwsza");
                }
                else if (x % i == 0)
                {
                    Console.WriteLine("Nie pierwsza");
                    break;
                }
                
                 
                

                
            }
            Console.ReadKey();
        }
    }
}
