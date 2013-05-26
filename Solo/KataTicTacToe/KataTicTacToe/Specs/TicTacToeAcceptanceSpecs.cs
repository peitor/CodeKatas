namespace KataTicTacToe.Specs
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
			this.game = new Game();
		}

		[TestMethod]
		public void Example_Play1Game_AsStartingExample()
		{
			this.game.Set(Player.P1, 0, 0);
			this.game.Set(Player.P2, 1, 1);
			this.game.Set(Player.P1, 1, 0);
			this.game.Set(Player.P2, 1, 2);
			this.game.Set(Player.P1, 2, 0);

			Assert.IsTrue(this.game.CalcWinner == Player.P1);
		}

		[TestMethod]
		public void Example_Play1Game_Player2Wins()
		{
			this.game.Set(Player.P1, 0, 0);
			this.game.Set(Player.P2, 1, 1);
			this.game.Set(Player.P1, 1, 0);
			this.game.Set(Player.P2, 0, 1);
			this.game.Set(Player.P1, 1, 2);
			this.game.Set(Player.P2, 2, 1);

			Assert.IsTrue(this.game.CalcWinner == Player.P2);
		}

		[TestMethod]
		public void OneMoveOnly_NoWinnerYet()
		{
			this.game.Set(Player.P1, 0, 0);
			Assert.IsTrue(this.game.CalcWinner == Player.None);
		}
		


		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Player1And2_SetOnSameLocation()
		{
			this.game.Set(Player.P1, 1, 1);
			this.game.Set(Player.P2, 1, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void PlayerPlaysTwice_NotAllowed()
		{
			this.game.Set(Player.P1, 1, 1);
			this.game.Set(Player.P1, 1, 1);
		}

		[TestMethod]
		public void AllowSetOfMarker_WhenISet1Marker_ThenTheMarkerShouldBeSet()
		{
			this.game.Set(Player.P1, 1, 1);
			this.game.FieldIsOccupied(1, 1);
		}

	
	}
}
// ReSharper restore InconsistentNaming
