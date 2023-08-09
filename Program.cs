
string boardTemplate = @"{""Field"": [
			[4, null, 5, null, 6, null, 7, null, null],
			[6, null, 2, null, null, null, null, 9, 3],
			[1, 9, 7, null, 3, null, null, 6, 2],
			[null, null, null, null, 9, null, 3, null, 7],
			[null, null, null, 6, 8, null, 9, 1, 5],
			[9, null, 1, null, 4, 3, null, 2, null],
			[5, 1, null, 3, 2, null, 8, null, 4],
			[null, 4, 8, null, null, 7, 1, null, 6],
			[7, null, 3, null, 1, null, null, 5, null]
		]}";

// Generate and Fill board
Board board = new();
board.FillBoard(boardTemplate);
board.PrintBoard();

// Solve board
Solver solver = new(board);
board = solver.SolveBoard();

Checker checker = new(board);

checker.IsValid();