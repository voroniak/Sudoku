using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
       static void test(string Path, int Size)
        {
            Sudoku sd = new Sudoku(Size);
            sd.ReadFromFile(Path);
            sd.PrintBoard();
            if (sd.Solve())
            {
                Console.WriteLine();
                Console.WriteLine();
                sd.PrintBoard();
                Console.WriteLine();
                Console.WriteLine($"Iterations count {sd.Counter}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("No answers");
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }
        static void Main(string[] args)
        {
            int Size = Int32.Parse(Console.ReadLine());
            Console.WriteLine("--------------board 1 ----------------------");
            test("board1.txt", Size);
            Console.WriteLine("--------------board 2 ----------------------");
            test("board2.txt", Size);
            Console.WriteLine("--------------board 3 ----------------------");
            test("board3.txt", Size);
            Console.WriteLine("--------------board 4 ----------------------");
            test("board4.txt", Size);
        }
    }
}
