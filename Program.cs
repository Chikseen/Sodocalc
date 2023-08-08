// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

int[][] boardTemplate = Templates.EveryFirstCorrect;

Board board = new();
board.FillBoard(boardTemplate);
board.PrintBoard();

Checker checker = new(board);

var checkWatch = Stopwatch.StartNew();
checker.IsValid();
Console.WriteLine($"Check needed {checkWatch.ElapsedMilliseconds}ms to execute");