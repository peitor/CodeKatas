namespace KataTicTacToe
{
	// ReSharper disable InconsistentNaming
	using System;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class TicTacToeAcceptanceSpecs
	{
		private Game game;

		[TestInitialize]
		public void TestSetup()
		{
			game = new Game();
		}

		[TestMethod]
		public void Example_Play1Game_AsStartingExample()
		{
			game.Set(Player.P1, 0, 0);
			game.Set(Player.P2, 1, 1);
			game.Set(Player.P1, 1, 0);
			game.Set(Player.P2, 1, 2);
			game.Set(Player.P1, 2, 0);

			Assert.IsTrue(game.CalcWinner == Player.P1);
		}

		[TestMethod]
		public void Example_Play1Game_Player2Wins()
		{
			game.Set(Player.P1, 0, 0);
			game.Set(Player.P2, 1, 1);
			game.Set(Player.P1, 1, 0);
			game.Set(Player.P2, 0, 1);
			game.Set(Player.P1, 1, 2);
			game.Set(Player.P2, 2, 1);

			Assert.IsTrue(game.CalcWinner == Player.P2);
		}

		[TestMethod]
		public void OneMoveOnly_NoWinnerYet()
		{
			game.Set(Player.P1, 0, 0);
			Assert.IsTrue(game.CalcWinner == Player.None);
		}
		


		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Player1And2_SetOnSameLocation()
		{
			game.Set(Player.P1, 1, 1);
			game.Set(Player.P2, 1, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void PlayerPlaysTwice_NotAllowed()
		{
			game.Set(Player.P1, 1, 1);
			game.Set(Player.P1, 1, 1);
		}

		[TestMethod]
		public void AllowSetOfMarker_WhenISet1Marker_ThenTheMarkerShouldBeSet()
		{
			game.Set(Player.P1, 1, 1);
			game.FieldIsOccupied(1, 1);
		}

	
	}
}
// ReSharper restore InconsistentNaming
