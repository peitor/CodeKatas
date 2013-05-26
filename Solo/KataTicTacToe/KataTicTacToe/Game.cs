namespace KataTicTacToe
{
	using System;

	using KataTicTacToe.Extensions;

	public class Game
	{
		private readonly string[,] board = new string[3, 3];
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
						this.IsFieldAPlayer(0, 2))
				{
					return this.board[0, 2].ToPlayer();
				}


				return Player.None;
			}
		}

		private bool IsFieldAPlayer(int x, int y)
		{
			return this.board[x, y].ToPlayer() != Player.None;
		}

		private bool AllDiagonalMarkersSame()
		{
			if (this.board[0, 0] == this.board[1, 1] &&
				this.board[1, 1] == this.board[2, 2])
			{
				return true;
			}
			return false;
		}

		private bool AllOtherDiagonalMarkersSame()
		{
			if (this.board[0, 2] == this.board[1, 1] &&
				this.board[1, 1] == this.board[2, 0])
			{
				return true;
			}
			return false;
		}



		private bool AllRowMarkersSame(int row)
		{
			if (this.board[0, row] == this.board[1, row] &&
				this.board[1, row] == this.board[2, row])
			{
				return true;
			}
			return false;
		}

		private bool AllColumnMarkersSame(int col)
		{
			if (this.board[col, 0] == this.board[col, 1] &&
				this.board[col, 1] == this.board[col, 2])
			{
				return true;
			}
			return false;

		}

		public Player FieldIsOccupiedWith(int x, int y)
		{
			return this.board[x, y].ToPlayer();
		}

		public string FieldIsOccupiedWithString(int x, int y)
		{
			// TODO: THIS IS BAD: Here we are breaking Law of demeter
			// publicly exposing the string, instead of Player
			return this.board[x, y];
		}

		public bool FieldIsOccupied(int x, int y)
		{
			return this.FieldIsOccupiedWith(x, y) != Player.None;
		}

	}
}