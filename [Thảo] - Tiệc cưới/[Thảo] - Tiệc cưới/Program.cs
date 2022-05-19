
using System;

namespace Input
{
    class program
    {
        static void Main(string[]args)
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            for (int i=1; i<=n; i++) {
                Console.Write(i+" ");
            }
        
        }

    }
}
