namespace KataReversi_TDDasyoumeantit
{
	using System.Security.Cryptography.X509Certificates;
	// ReSharper disable InconsistentNaming
	using System;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class KataReversiSpecs
	{
		private string[,] emptyBoard0By0;

		private string[,] emptyBoardOneByOne;

		private string[,] emptyBoard2By2;

		private string[,] currentBoard;

		private const string drawGame = "draw";

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
			string winner = CalcWinner(this.currentBoard, this.emptyBoardOneByOne, "black");
			
			Assert.AreEqual(blackPlayer, winner);
		}

		[TestMethod]
		public void GivenAEmptyBoard2By2_GameIsDraw__NoTokenWouldBeFlipped()
		{
			currentBoard = emptyBoard2By2;
			string winner =  CalcWinner(this.currentBoard, this.emptyBoard2By2, drawGame);
			
			Assert.AreEqual(drawGame, winner);
		}

		[TestMethod]
		public void GivenAStartingReversiBoard2By2_GameIsDraw__NoTokenCanBePlaced()
		{
			var initialSetup = CreateInitialSetup();

			currentBoard = initialSetup;
			string winner = CalcWinner(this.currentBoard, initialSetup, drawGame);
			
			Assert.AreEqual(drawGame, winner);
		}


		[TestMethod]
		public void GivenAStartingReverisBoard_BlackPlacesTokenOntheBottomWhereItCanFlipWhiteToken_OneWhiteTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			expectedBoard[1, 1] = "B";
			expectedBoard[2, 1] = "B";
			this.currentBoard = CreateInitialSetup();
			
			//act
			currentBoard[2, 1] = "B";

			//production code
			currentBoard[1, 1] = "B";
			
			CollectionAssert.AreEqual(expectedBoard,  currentBoard);
		}


		[TestMethod]
		public void GivenAStartingReverisBoard_BlackPlacesTokenOntheRightWhereItCanFlipWhiteToken_OneWhiteTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			expectedBoard[1, 1] = "B";
			expectedBoard[1, 2] = "B";
			this.currentBoard = CreateInitialSetup();

			//act
			currentBoard[1, 2] = "B";

			// flipped token
			currentBoard[1, 1] = "B";
		
			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}

		[TestMethod]
		public void GivenAStartingReverisBoard_BlackPlacesTokenOntheLeftWhereItCanFlipWhiteToken_OneWhiteTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			Action<string[,], int, int, string> placeToken = delegate(string[,] strings, int x, int y, string player)
			{
				int boardOnTopLeftSide = -1;
				strings[(boardOnTopLeftSide)*x, y] = player;
			};

			placeToken(expectedBoard, -1, 0, "B");
			placeToken(expectedBoard, 0, 0, "B");
			
			this.currentBoard = CreateInitialSetup();

			//act
			placeToken(expectedBoard, -1, 0, "B");

			// prod code
			placeToken(currentBoard, 0, 0, "B");


			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}


		// Next steps: have more "placeToken" delegates and extract them
		// Black Places Top Flip White Token

		
		private static string[,] CreateInitialSetup()
		{
			string[,] initialSetup = InitializeEmptyBoardWithSize(3);
			initialSetup[0, 0] = "W";
			initialSetup[0, 1] = "B";
			initialSetup[1, 1] = "W";
			initialSetup[1, 0] = "B";
			return initialSetup;
		}

		private static string CalcWinner(string[,] currentBoardToCheck, string[,] winningBoard, string winner)
		{
			return currentBoardToCheck == winningBoard ? winner : "Game can continue";
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
// ReSharper restore InconsistentNaming
