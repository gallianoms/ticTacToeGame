using System;
using System.Data;
using System.Runtime.Intrinsics.X86;

void TicTacToe()
{
	bool Xturn = true;
	int numShift = 9;

	char?[][] board = new char?[3][]
	{
	new char?[3] { null, null, null },
	new char?[3] { null, null, null },
	new char?[3] { null, null, null }
	};

	Console.WriteLine(board[0][0]);

	do
	{
		numShift--;

		if (Xturn)
		{
			Call(board, ref Xturn);
			PrintBoard(board);

			if (Match(board, 'X'))
			{
				Console.WriteLine("X win... CONGRATULATIONS");
				break;
			}

		}
		else
		{
			Call(board, ref Xturn);
			PrintBoard(board);

			if (Match(board, 'O'))
			{
				Console.WriteLine("O win... CONGRATULATIONS");
				break;
			}

		}

		if (numShift == 0 && !Match(board, 'X') && !Match(board, 'O'))
		{
			Console.WriteLine("Draw");
			break;
		}

	} while (numShift != 0);

	Console.ReadKey();
}

void PrintBoard(char?[][] board)
{
	foreach (char?[] row in board)
	{
		Console.WriteLine(string.Join(" | ", row.Select(cell => cell.HasValue ? cell.Value.ToString() : " ")));
		Console.WriteLine("----------- \n");
	}
}

void Call(char?[][] board, ref bool Xturn)
{
	if (Xturn)
	{
		Console.WriteLine("X turn");
	}
	else
	{
		Console.WriteLine("O turn");
	}

	Console.Write("enter row: ");
	int row = Convert.ToInt32(Console.ReadLine());

	Console.Write("enter column: ");
	int column = Convert.ToInt32(Console.ReadLine());

	if (board[row][column] != null)
	{
		Console.WriteLine("\n");
		Console.WriteLine("Position already occupied...");
		Call(board, ref Xturn);
		return;
	}

	board[row][column] = Xturn ? 'X' : 'O';
	Xturn = !Xturn;

	Console.WriteLine("\n");

}

bool Match(char?[][] board, char symbol)
{
	// verticals / horizontals check
	for (int i = 0; i < 3; i++)
	{
		if (board[i][0] == symbol && board[i][1] == symbol && board[i][2] == symbol)
		{
			return true;
		}
		if (board[0][i] == symbol && board[1][i] == symbol && board[2][i] == symbol)
		{
			return true;
		}
	}

	// diagonals check
	if (board[0][0] == symbol && board[1][1] == symbol && board[2][2] == symbol)
	{
		return true;
	}
	if (board[0][2] == symbol && board[1][1] == symbol && board[2][0] == symbol)
	{
		return true;
	}
	return false;
}

TicTacToe();

