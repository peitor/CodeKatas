namespace KataTicTacToe.Extensions
{
	public static class PlayerExt
	{
		public static string PlayerToString(this Player player)
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
	}
}