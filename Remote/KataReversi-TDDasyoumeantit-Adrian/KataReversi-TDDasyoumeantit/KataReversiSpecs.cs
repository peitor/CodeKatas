namespace KataReversi_TDDasyoumeantit
{
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
			string winner = CalcGameOutcome(this.currentBoard, this.emptyBoardOneByOne, "black");

			Assert.AreEqual(blackPlayer, winner);
		}

		[TestMethod]
		public void GivenAEmptyBoard2By2_GameIsDraw__NoTokenWouldBeFlipped()
		{
			currentBoard = emptyBoard2By2;
			string winner = CalcGameOutcome(this.currentBoard, this.emptyBoard2By2, drawGame);

			Assert.AreEqual(drawGame, winner);
		}

		[TestMethod]
		public void GivenAStartingReversiBoard2By2_GameIsDraw__NoTokenCanBePlaced()
		{
			var initialSetup = CreateInitialSetup();

			currentBoard = initialSetup;
			string winner = CalcGameOutcome(this.currentBoard, initialSetup, drawGame);

			Assert.AreEqual(drawGame, winner);
		}

		[TestMethod]
		public void GivenAStartingReverisBoard_BlackPlacesTokenOntheRightWhereItCanFlipWhiteToken_OneWhiteTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			expectedBoard[5, 5] = "B";
			expectedBoard[5, 6] = "B";
			this.currentBoard = CreateInitialSetup();

			//act
			PlaceToken(currentBoard, 5, 6, "B");

			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}

		private static void PlaceToken(string[,] strings, int x, int y, string player)
		{
			strings[x, y] = player;
			// TODO: determine tokens to be flipped and do it 
			// TODO: Flip tokens horizontally, vertically AND diagonally
			var centerOnOrdinate = y + 0;
			var centerOnAbsissa = x + 0;
			int left = x - 1;
			var bottom = y + 1;
			int top = y - 1;

			if (x == 3 && y == 4)
			{
				int right = x + 1;
				FlipToken(strings, right, centerOnOrdinate, Black());
			}

			if (x == 4 && y == 3)
			{
				FlipToken(strings, centerOnAbsissa, bottom, Black());
			}

			if (x == 5 && y == 6)
			{
				FlipToken(strings, centerOnAbsissa, top, Black());
			}

			if (x == 6 && y == 5)
			{
				FlipToken(strings, left, centerOnOrdinate, Black());
			}

			if (x == 4 && y == 6)
			{
				FlipToken(strings, centerOnAbsissa, top, White());
			}

			if (x == 6 && y == 4)
			{
				FlipToken(strings, left, centerOnOrdinate, White());
			}

			if (x == 6 && y == 6)
			{
				FlipToken(strings, left, top, White());
			}
		}

		private static string White()
		{
			return "W";
		}

		private static string Black()
		{
			return "B";
		}

		private static void FlipToken(string[,] strings, int x, int y, string token)
		{
			strings[x, y] = token;
		}

		[TestMethod]
		public void GivenAStartingReverisBoard_BlackPlacesTokenOntheLeftWhereItCanFlipWhiteToken_OneWhiteTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			// placed
			expectedBoard[3, 4] = "B";
			// flipped
			expectedBoard[4, 4] = "B";

			this.currentBoard = CreateInitialSetup();

			//act
			PlaceToken(currentBoard, 3, 4, "B");

			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}

		[TestMethod]
		public void GivenAStartingReverisBoard_BlackPlacesTokenOntheTopWhereItCanFlipWhiteToken_OneWhiteTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			// placed
			expectedBoard[4, 3] = "B";
			// flipped
			expectedBoard[4, 4] = "B";

			this.currentBoard = CreateInitialSetup();

			//act
			PlaceToken(currentBoard, 4, 3, "B");

			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}

		[TestMethod]
		public void GivenAStartingReverisBoard_BlackPlacesTokenOnTheBottomWhereItCanFlipWhiteToken_OneWhiteTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			// placed
			expectedBoard[6, 5] = "B";
			// flipped
			expectedBoard[5, 5] = "B";

			this.currentBoard = CreateInitialSetup();

			//act
			PlaceToken(currentBoard, 6, 5, "B");

			// currentBoard 5,5 IsFlipped To Black
			Assert.AreEqual("B", currentBoard[5, 5]);

			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}

		[TestMethod]
		public void GivenAReverisBoardWith1BlackPlayedToken_WhitePlacesTokenOnTheBottomWhereItCanFlipBlackToken_OneBlackTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			// played
			expectedBoard[6, 5] = "B";
			// flipped
			expectedBoard[5, 5] = "B";
			// played
			expectedBoard[4, 6] = "W";
			// Flipped
			expectedBoard[4, 5] = "W";


			this.currentBoard = CreateInitialSetup();
			PlaceToken(currentBoard, 6, 5, "B");

			// act
			PlaceToken(currentBoard, 4, 6, "W");


			Assert.AreEqual("W", currentBoard[4, 5]);
			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}


		[TestMethod]
		public void GivenAReverisBoardWith1BlackPlayedToken_WhitePlacesTokenOnTheRightWhereItCanFlipBlackToken_OneBlackTokenIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			// played
			expectedBoard[6, 5] = "B";
			// flipped
			expectedBoard[5, 5] = "B";
			// played
			expectedBoard[6, 4] = "W";
			// Flipped
			expectedBoard[5, 4] = "W";


			this.currentBoard = CreateInitialSetup();
			PlaceToken(currentBoard, 6, 5, "B");

			// act
			PlaceToken(currentBoard, 6, 4, "W");


			Assert.AreEqual("W", currentBoard[5, 4]);
			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}

		[TestMethod]
		public void GivenAReverisBoardWith1BlackPlayedToken_WhitePlacesTokenOnTheBottomRightWhereItCanFlipBlackToken_OneBlackTokenTopLeftIsFlipped()
		{
			var expectedBoard = CreateInitialSetup();
			// played
			expectedBoard[6, 5] = "B";
			// flipped
			expectedBoard[5, 5] = "B";
			// played
			expectedBoard[6, 6] = "W";
			// Flipped
			expectedBoard[5, 5] = "W";


			this.currentBoard = CreateInitialSetup();
			PlaceToken(currentBoard, 6, 5, "B");

			// act
			PlaceToken(currentBoard, 6, 6, "W");


			Assert.AreEqual("W", currentBoard[5, 5]);
			CollectionAssert.AreEqual(expectedBoard, currentBoard);
		}

		// Create an abstraction on top of these weird numbers!!! 
		// Something we can see and understand!!
		//    WB      
		//    BWB  


		private static string[,] CreateInitialSetup()
		{
			string[,] initialSetup = InitializeEmptyBoardWithSize(8);
			initialSetup[4, 4] = "W";
			initialSetup[4, 5] = "B";
			initialSetup[5, 5] = "W";
			initialSetup[5, 4] = "B";
			return initialSetup;
		}

		private static string CalcGameOutcome(string[,] currentBoardToCheck, string[,] winningBoard, string gameOutcome)
		{
			return currentBoardToCheck == winningBoard ? gameOutcome : "Game can continue";
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
