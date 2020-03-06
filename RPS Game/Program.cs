using System;

namespace RPS_Game
{
    class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game();
            //bool gameOver = game.CheckGame();
            game.GameNumbers = Introduction();
            do
            {
                game.PlayGame();
            } while (game.GameOver == false);


            //game is now over, display total score.
            Console.WriteLine($"\nGame Finished! Final Score:");
            game.DisplayResults();

        }

        static int Introduction()
        {
            Console.WriteLine("Best of how many games?");

            string gamesString;

            do
            {
                Console.WriteLine("1, 3, or 5?");
                gamesString = Console.ReadLine();
            }
            while (gamesString != "1" && gamesString != "3" && gamesString != "5");


            int gamesNumber = Int32.Parse(gamesString);
            Console.WriteLine($"You selected {gamesNumber} games.");

            return gamesNumber;
        }


    }
}
