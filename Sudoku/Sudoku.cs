using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
        public int Counter { get; protected set; }
        int Size { get;  }
        private List<List<int>> _board = new List<List<int>>();
        public Sudoku(int Size)
        {

            this.Size = Size;
            if (Math.Sqrt(Size) % 1 != 0)
            {
                throw new Exception("Incorrect board dimension");
            }
            Counter = 0;
            for(int i = 0; i < Size; i++)
            {
                _board.Add(new List<int>());
            }
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _board[i].Add(0);
                }
            }
        }
        public void ReadFromFile(string Path)
        {
            using (StreamReader  sr = new StreamReader(Path))
            {
              
                
                for (int i = 0; i < Size; i++)
                {
                    string[] info = sr.ReadLine().Split();
                    for (int j = 0; j < Size; j++)
                    {
                       _board[i][j] = Int32.Parse(info[j]);
                    }
                }
            }
        }
        public void PrintBoard()
        {

            for (int i = 0; i < Size; i++)
            {
                if(i % Math.Sqrt(Size) == 0 && i != 0)
                {
                    Console.WriteLine("---------------------------");
                }
                for (int j = 0; j < Size; j++)
                {
                   if(j % Math.Sqrt(Size) == 0 && j != 0)
                    {
                        Console.Write('|');
                    }
                    Console.Write(_board[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }
        private List<int> FindEmpty()
        {
            for(int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_board[i][j] == 0)
                    {
                        return new List<int>() { i, j };
                    }
                }
            }
            return new List<int>() { -1, -1 };
        }
        private bool Valid (int number, List<int> position)
        {
            // check line 
            for(int i = 0; i < Size; i++)
            {
                if( _board[position[0]][i] == number && position[1] != i)
                {
                    return false;
                }
            }
            // check column 
            for (int i = 0; i < Size; i++)
            {
                if (_board[i][position[1]] == number && position[0] != i)
                {
                    return false;
                }
            }
            // check square 
            int x = position[1] / (int)Math.Sqrt(Size);
            int y = position[0] / (int)Math.Sqrt(Size);
            for(int i = y* (int)Math.Sqrt(Size); i < y* Math.Sqrt(Size) + Math.Sqrt(Size); i++)
            {
                for (int j = x * (int)Math.Sqrt(Size); j < x * Math.Sqrt(Size) + Math.Sqrt(Size); j++)
                {
                    if (_board[i][j] == number && (position[0] != i && position[1] != j)){
                        return false;
                    }
                }

            }
            // check the diagonal 
            if (position[0] == position[1])
            {
                for (int i = 0; i < Size; i++)
                {
                    if (_board[i][i] == number && (position[0] != i && position[1] != i))
                    {
                        return false;
                    }
                }
            }
            else if ( position[0] + position[1] == Size - 1)
            {
                for (int i = 0; i < Size; i++)
                {
                    if (_board[i][Size - i - 1] == number)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    public bool Solve()
        {
            var position = FindEmpty();
            int row = position[0];
            int col = position[1];
            if (row == -1)
            {
                return true;
            }
            else
            {
                for(int i = 1; i < Size+1; i++)
                {
                    if (Valid(i, position))
                    {
                        _board[row][col] = i;
                        Counter++;
                        if (Solve())
                        {
                            return true;
                        }
                        _board[row][col] = 0;
                    }
                }
            }
     
            return false;
        }
    }
}
