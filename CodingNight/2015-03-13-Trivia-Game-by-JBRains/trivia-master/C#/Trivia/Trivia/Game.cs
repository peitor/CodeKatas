namespace Trivia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private readonly bool[] inPenaltyBox = new bool[6];

        private readonly int[] places = new int[6];

        private readonly List<string> players = new List<string>();

        private readonly LinkedList<string> popQuestions = new LinkedList<string>();

        private readonly int[] purses = new int[6];

        private readonly LinkedList<string> rockQuestions = new LinkedList<string>();

        private readonly LinkedList<string> scienceQuestions = new LinkedList<string>();

        private readonly LinkedList<string> sportsQuestions = new LinkedList<string>();

        private int currentPlayer;

        private bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                this.popQuestions.AddLast("Pop Question " + i);
                this.scienceQuestions.AddLast(("Science Question " + i));
                this.sportsQuestions.AddLast(("Sports Question " + i));
                this.rockQuestions.AddLast("Rock Question " + i);
            }
        }

        public bool IsPlayable()
        {
            return (this.HowManyPlayers() >= 2);
        }

        public bool AddPlayer(String playerName)
        {
            this.players.Add(playerName);
            this.places[this.HowManyPlayers()] = 0;
            this.purses[this.HowManyPlayers()] = 0;
            this.inPenaltyBox[this.HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + this.players.Count);
            return true;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(this.players[this.currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (this.inPenaltyBox[this.currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    this.isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(this.players[this.currentPlayer] + " is getting out of the penalty box");
                    this.Move(roll);
                    this.AskQuestion();
                }
                else
                {
                    Console.WriteLine(this.players[this.currentPlayer] + " is not getting out of the penalty box");
                    this.isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                this.Move(roll);
                this.AskQuestion();
            }
        }

        public void WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(this.players[this.currentPlayer] + " was sent to the penalty box");
            this.inPenaltyBox[this.currentPlayer] = true;

            this.NextPlayer();
        }

        public bool WasLoser()
        {
            if (this.inPenaltyBox[this.currentPlayer])
            {
                if (!this.isGettingOutOfPenaltyBox)
                {
                    this.NextPlayer();
                    return true;
                }
            }

            this.AnswerWasCorrect();
            var notWinner = this.NotWinner();
            this.NextPlayer();

            return notWinner;
        }

        private void Move(int roll)
        {
            this.places[this.currentPlayer] = this.places[this.currentPlayer] + roll;
            if (this.places[this.currentPlayer] > 11)
            {
                this.places[this.currentPlayer] = this.places[this.currentPlayer] - 12;
            }

            Console.WriteLine(this.players[this.currentPlayer] + "'s new location is " + this.places[this.currentPlayer]);
            Console.WriteLine("The category is " + this.CurrentCategory());
        }

        private void AnswerWasCorrect()
        {
            Console.WriteLine("Answer was correct!!!!");
            this.purses[this.currentPlayer]++;
            Console.WriteLine(this.players[this.currentPlayer] + " now has " + this.purses[this.currentPlayer] + " Gold Coins.");
        }

        private void NextPlayer()
        {
            this.currentPlayer++;
            if (this.currentPlayer == this.players.Count)
            {
                this.currentPlayer = 0;
            }
        }

        private bool NotWinner()
        {
            return this.purses[this.currentPlayer] != 6;
        }

        private int HowManyPlayers()
        {
            return this.players.Count;
        }

        private string CurrentCategory()
        {
            switch (this.places[this.currentPlayer])
            {
                case 0:
                    return "Pop";
                case 4:
                    return "Pop";
                case 8:
                    return "Pop";
                case 1:
                    return "Science";
                case 5:
                    return "Science";
                case 9:
                    return "Science";
                case 2:
                    return "Sports";
                case 6:
                    return "Sports";
                case 10:
                    return "Sports";
            }

            return "Rock";
        }

        private void AskQuestion()
        {
            LinkedList<string> currentQuestions = null;
            switch (this.CurrentCategory())
            {
                case "Pop":
                    currentQuestions = this.popQuestions;
                    break;
                case "Science":
                    currentQuestions = this.scienceQuestions;
                    break;
                case "Sports":
                    currentQuestions = this.sportsQuestions;
                    break;
                case "Rock":
                    currentQuestions = this.rockQuestions;
                    break;
            }

            Console.WriteLine(currentQuestions.First());
            currentQuestions.RemoveFirst();
        }
    }
}