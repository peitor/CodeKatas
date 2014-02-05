namespace RedPencilCodeKata
{
	using System;

	public static class Time
	{
		private static DateTime now = DateTime.Now;
		public static DateTime Now
		{
			get
			{

				return now;
			}
		}

		public static void GoForwardInDays(int days)
		{
			now = now.AddDays(days);
		}
	}
}