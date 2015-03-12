using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UglyTrivia
{
    public class Game
    {


        List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(createRockQuestion(i));
            }
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {
            players.Add(playerName);
            places[howManyPlayers()] = 0;
            purses[howManyPlayers()] = 0;
            inPenaltyBox[howManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return players.Count;
        }

        public void roll(int roll)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                    this.Move(roll);
                    this.askQuestion();
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                this.Move(roll);
                this.askQuestion();
            }

        }

        private void Move(int roll)
        {
            this.places[this.currentPlayer] = this.places[this.currentPlayer] + roll;
            if (this.places[this.currentPlayer] > 11)
            {
                this.places[this.currentPlayer] = this.places[this.currentPlayer] - 12;
            }

            Console.WriteLine(this.players[this.currentPlayer] + "'s new location is " + this.places[this.currentPlayer]);
            Console.WriteLine("The category is " + this.currentCategory());
           
        }

        private void askQuestion()
        {
            LinkedList<string> currentQuestions = null;
            if (currentCategory() == "Pop")
            {
                currentQuestions = popQuestions;
            }
            if (currentCategory() == "Science")
            {
                currentQuestions = scienceQuestions;
            }
            if (currentCategory() == "Sports")
            {
                currentQuestions = sportsQuestions;
            }
            if (currentCategory() == "Rock")
            {
                currentQuestions = rockQuestions;
            }
            Console.WriteLine(currentQuestions.First());
            currentQuestions.RemoveFirst();
        }


        private String currentCategory()
        {
            if (places[currentPlayer] == 0) return "Pop";
            if (places[currentPlayer] == 4) return "Pop";
            if (places[currentPlayer] == 8) return "Pop";
            if (places[currentPlayer] == 1) return "Science";
            if (places[currentPlayer] == 5) return "Science";
            if (places[currentPlayer] == 9) return "Science";
            if (places[currentPlayer] == 2) return "Sports";
            if (places[currentPlayer] == 6) return "Sports";
            if (places[currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    return this.WasCorrectlyAnswered();
                }
                else
                {
                    this.NextPlayer();
                    return true;
                }
            }
            else
            {

                return this.WasCorrectlyAnswered();
            }
        }

        private bool WasCorrectlyAnswered()
        {
            Console.WriteLine("Answer was correct!!!!");
            this.purses[this.currentPlayer]++;
            Console.WriteLine(this.players[this.currentPlayer] + " now has " + this.purses[this.currentPlayer] + " Gold Coins.");

            bool winner = this.didPlayerWin();

            this.NextPlayer();

            return winner;
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            this.NextPlayer();
            return true;
        }

        private void NextPlayer()
        {
            this.currentPlayer++;
            if (this.currentPlayer == this.players.Count)
            {
                this.currentPlayer = 0;
            }
        }

        private bool didPlayerWin()
        {
            return !(purses[currentPlayer] == 6);
        }
    }

}
