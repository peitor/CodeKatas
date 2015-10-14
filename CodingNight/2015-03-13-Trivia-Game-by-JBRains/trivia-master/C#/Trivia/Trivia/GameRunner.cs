namespace Trivia
{
    using System;

    public class GameRunner
    {
        private static bool isWinnerDetermined;

        public static void Main(String[] args)
        {
            Random rand = new Random();
            if (args.Length == 1)
            {
                rand = new Random(Convert.ToInt32(args[0]));
            }

            Game aGame = new Game();

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    aGame.WrongAnswer();
                }
                else
                {
                    isWinnerDetermined = !aGame.WasLoser();
                }
            }
            while (!isWinnerDetermined);
        }
    }
}