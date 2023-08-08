// See https://aka.ms/new-console-template for more information

Board board = new();
board.FillBoard();
board.PrintBoard();

Solver solver = new(board);
solver.IsValid();