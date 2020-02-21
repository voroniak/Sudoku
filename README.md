# Sudoku
# Description:
A class that can solve sudoku of any (correct) size* by using Backtracking algorithm. This program might have give you understand how recursion, Backtracking algorithm
works and give you an example where you can use it.
 -    '*' - size is correct when sqrt(size) is natural number
# Class possibilities:
- solve sudoku of any (correct) size;
  # Methods and properties
  |  Method | Description |
  |---------|:-----------:|
  | public void PrintBoard() | print board on console |
  |  private List<int> FindEmpty() | find first empty element and return`s his position|
  | private bool Valid (int number, List<int> position)| checks if numer is able to be next on line, column or squares |
  | public bool Solve() | recursive mathod what solve sudoku and returns true if answers has|
  | public int Counter { get; protected set; }|shows how many sudoku attempts have been resolved|
  | int Size { get;  } | board size |
  | private List<List<int>> _board = new List<List<int>>() | board |
