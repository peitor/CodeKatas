namespace KataTicTacToe
{
	using System;

	public class Game
	{
		private readonly string[,] board = new string[3, 3];
		private Player lastSetPlayer;

		public Game()
			: this("", 3)
		{

		}

		public Game(string initialBoard, int boardSize)
		{
			board = new string[boardSize, boardSize];
			int posi = 0;
			foreach (char marker in initialBoard)
			{
				int x = posi % boardSize;
				int y = posi / boardSize;

				board[x, y] = marker.ToString();
				posi++;
			}
		}

		public Player Winner
		{
			get
			{
				if (this.AllRowMarkersSame(0)
					&&
					this.board[0, 0].ToPlayer() != Player.None)
				{
					return this.board[0, 0].ToPlayer();
				}

				if (this.AllRowMarkersSame(1)
					&&
					this.board[0, 1].ToPlayer() != Player.None)
				{
					return this.board[0, 1].ToPlayer();
				}

				if (this.AllRowMarkersSame(2)
					&&
					this.board[0, 2].ToPlayer() != Player.None)
				{
					return this.board[0, 2].ToPlayer();
				}



				return Player.None;
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

			this.board[x, y] = ConvertPlayerToString(p);
			this.lastSetPlayer = p;
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

		private bool AllRowMarkersSame(int row, Player player)
		{
			var marker = this.ConvertPlayerToString(player);
			if (this.board[0, row] == marker && this.board[1, row] == marker && this.board[2, row] == marker)
			{
				return true;
			}
			return false;
		}

		public Player FieldIsOccupiedWith(int x, int y)
		{
			return this.board[x, y].ToPlayer();
		}

		// TODO: THIS IS BAD: Here we are breaking Law of demeter
		// publicly exposing the string, instead of Player
		public string FieldIsOccupiedWithString(int x, int y)
		{
			return this.board[x, y];
		}


		public bool FieldIsOccupied(int x, int y)
		{
			return FieldIsOccupiedWith(x, y) != Player.None;
		}


		private string ConvertPlayerToString(Player player)
		{
			switch (player)
			{
				case Player.P1:
					return "X";
				case Player.P2:
					return "O";
			}
			return ".";
		}

		//private Player ConvertStringToPlayer(string s)
		//{
		//	switch (s)
		//	{
		//		case "X":
		//			return Player.P1;
		//		case "O":
		//			return Player.P2;
		//	}
		//	return Player.None;
		//}

	}

	public static class StringExt
	{
		public static Player ToPlayer(this string s)
		{
			switch (s)
			{
				case "X":
					return Player.P1;
				case "O":
					return Player.P2;
			}
			return Player.None;
		}
	}
}