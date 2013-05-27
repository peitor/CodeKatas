namespace KataTicTacToe
{
	using System;

	using KataTicTacToe.Extensions;

	public class Game
	{
		private readonly string[,] board;
		private Player lastSetPlayer;
		private readonly int boardsize;

		public Game()
			: this("", 3)
		{

		}

		public Game(string initialBoard, int boardSize)
		{
			if (initialBoard.Length > boardSize * boardSize)
			{
				throw new ArgumentException("Initial Board is bigger than the board itself");
			}

			this.boardsize = boardSize;
			this.board = new string[boardSize, boardSize];
			int posi = 0;
			foreach (char marker in initialBoard)
			{
				int x = posi % boardSize;
				int y = posi / boardSize;

				this.board[x, y] = marker.ToString();
				posi++;
			}
		}


		public void Set(Player p, int x, int y)
		{
			if (p == this.lastSetPlayer)
			{
				throw new InvalidOperationException();
			}

			if (this.FieldIsOccupied(x, y))
			{
				throw new InvalidOperationException();
			}

			this.board[x, y] = p.PlayerToString();
			this.lastSetPlayer = p;
		}

		public Player CalcWinner
		{
			get
			{

				for (int i = 0; i < this.boardsize; i++)
				{
					if (this.AllRowMarkersSame(i)
						&&
						this.IsFieldAPlayer(0, i))
					{
						return this.board[0, i].ToPlayer();
					}


					if (this.AllColumnMarkersSame(i)
						&&
						this.IsFieldAPlayer(i, 0))
					{
						return this.board[i, 0].ToPlayer();
					}
				}

				if (this.AllDiagonalMarkersSame()
						&&
						this.IsFieldAPlayer(0, 0))
				{
					return this.board[0, 0].ToPlayer();
				}


				if (this.AllOtherDiagonalMarkersSame()
						&&
						this.IsFieldAPlayer(0, boardsize - 1))
				{
					return this.board[0, boardsize - 1].ToPlayer();
				}


				return Player.None;
			}
		}

		private bool FieldIsOccupied(int x, int y)
		{
			return this.FieldIsOccupiedWith(x, y) != Player.None;
		}

		private bool IsFieldAPlayer(int x, int y)
		{
			return this.board[x, y].ToPlayer() != Player.None;
		}

		private bool AllDiagonalMarkersSame()
		{
			var playerFound = this.board[0, 0];

			for (int i = 0; i < boardsize; i++)
			{
				if (playerFound != this.board[i, i])
				{
					return false;
				}
			}
			return true;

		}

		private bool AllOtherDiagonalMarkersSame()
		{
			var playerFound = this.board[0, boardsize - 1];

			for (int i = 0; i < boardsize; i++)
			{
				if (playerFound != this.board[i, boardsize - 1 - i])
				{
					return false;
				}
			}
			return true;
		}

		private bool AllRowMarkersSame(int row)
		{
			var playerFound = this.board[0, row];

			for (int i = 0; i < boardsize; i++)
			{
				if (playerFound != this.board[i, row])
				{
					return false;
				}
			}
			return true;
		}

		private bool AllColumnMarkersSame(int col)
		{
			var playerFound = this.board[col, 0];

			for (int i = 0; i < boardsize; i++)
			{
				if (playerFound != this.board[col, i])
				{
					return false;
				}
			}
			return true;
		}

		private Player FieldIsOccupiedWith(int x, int y)
		{
			return this.board[x, y].ToPlayer();
		}
	}
}