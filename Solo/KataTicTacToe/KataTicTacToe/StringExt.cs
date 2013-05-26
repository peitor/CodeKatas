namespace KataTicTacToe
{
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