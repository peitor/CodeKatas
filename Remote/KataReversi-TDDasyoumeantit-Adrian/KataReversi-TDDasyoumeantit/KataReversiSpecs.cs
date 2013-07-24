namespace KataReversi_TDDasyoumeantit
{
	using System;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class KataReversiSpecs
	{
		private string[,] emptyBoard0By0;

		private string[,] emptyBoardOneByOne;

		private string[,] emptyBoard2By2;

		private string[,] currentBoard;


		private static string[,] InitializeEmptyBoardWithSize(int boardSize)
		{
			return new string[boardSize, boardSize];
		}

		[TestInitialize]
		public void Setup()
		{
			this.emptyBoard0By0 = InitializeEmptyBoardWithSize(0);
			this.emptyBoardOneByOne = InitializeEmptyBoardWithSize(1);
			this.emptyBoard2By2 = InitializeEmptyBoardWithSize(2);
		}

		[TestMethod]
		public void GivenAnSimplestReversiBoardEver_NoTokenPlacementPossible()
		{
			int expectedTokenPossibilitiesCount = 0;
			Func<int> computePossibleNumberOfPlacements = () => 2;

			currentBoard = this.emptyBoard0By0;
			int tokenPlacementPossiblitiesCount = currentBoard == this.emptyBoard0By0 ? 0 : computePossibleNumberOfPlacements();

			Assert.AreEqual(expectedTokenPossibilitiesCount, tokenPlacementPossiblitiesCount);
		}


		[TestMethod]
		public void GivenAnEmptyReversiBoardOneByOne_WhenBlackPlacesToken_BlackWins()
		{
			string blackPlayer = "black";

			currentBoard = this.emptyBoardOneByOne;
			string winner = currentBoard == this.emptyBoardOneByOne ? "black" : "Game can continue";
			
			Assert.AreEqual(blackPlayer, winner);
		}


		[TestMethod]
		public void GivenAEmptyBoard2By2_GameIsDraw__NoTokenWouldBeFlipped()
		{
			string drawGame = "draw";

			currentBoard = emptyBoard2By2;
			string winner = currentBoard == emptyBoard2By2 ? "draw" : "Game can continue";
			
			Assert.AreEqual(drawGame, winner);
		}

		[TestMethod]
		public void GivenAStartingReversiBoard2By2_GameIsDraw__NoTokenCanBePlaced()
		{
			var drawGame = "draw"; 
			string[,] initialSetup = this.emptyBoard2By2;
			initialSetup[0, 0] = "B";
			initialSetup[0, 1] = "W";
			initialSetup[1, 1] = "B";
			initialSetup[1, 0] = "W";

			currentBoard = initialSetup;
			string winner = currentBoard == initialSetup ? "draw" : "Game can continue";
			
			Assert.AreEqual(drawGame, winner);
		}

		//[TestMethod]
		//public void WhenCanIPlaceAToken()
		//{
		//	string[,] board = new string[3, 3];

		//	// 2x2 board with white and black tokens on the diagonal


		//	// 

		//	// Token placement possibilities = 0
		//	Assert.AreEqual(0, tokenPlacementPossiblitiesCount);
		//}
	}
}
