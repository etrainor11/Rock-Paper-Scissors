using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Game
    {
        public int GameNumbers { get; set; }
        public int CurrentGame { get; set; }

        public int PlayerWinsNumber { get; set; }
        public int CompWinsNumber { get; set; }

        Rock_Paper_Scissors.Objs playerObj;
        Rock_Paper_Scissors.Objs comObj;

        public bool GameOver { get; set; }
        public void PlayGame()
        {
            StartGame();
            PlayerPick();
            ComputerPick();
            CheckWinner(playerObj, comObj);
            DisplayResults();
            GameOver = CheckGame();
        }

        void StartGame()
        {
            CurrentGame++;
            Console.WriteLine($"Game number {CurrentGame}: \n");
        }

        void PlayerPick()
        {
            string answer;
            do
            {
                Console.WriteLine("Rock, Paper, or Scissors?");
                string a = Console.ReadLine();
                answer = a.ToLower();
            } while (answer != "rock" && answer != "paper" && answer != "scissors");

            Console.WriteLine($"You selected {answer} \n");

            playerObj = DeclareChoice(answer);
        }

        void ComputerPick()
        {
            int l = (Enum.GetNames(typeof(Rock_Paper_Scissors.Objs)).Length) - 1;
            var r = new Random();
            int ran = r.Next(0, l + 1);
            string answer = Enum.GetName(typeof(Rock_Paper_Scissors.Objs), ran);
            Console.WriteLine($"Computer has picked {answer.ToLower()} \n");
            comObj = DeclareChoice(answer);
        }

        public bool CheckGame()
        {
            bool gameOver;
            double total = Convert.ToDouble(GameNumbers);
            double current = Convert.ToDouble(CurrentGame);

            //If the player or computer have more than half the matches won they mathmatically win.
            if ((total / 2) < PlayerWinsNumber || (total / 2) < CompWinsNumber)
            {
                gameOver = true;
            }
            else if (CurrentGame > GameNumbers)
            {
                gameOver = true;
            }
            else
            {
                gameOver = false;
            }

            return gameOver;
        }

        private Rock_Paper_Scissors.Objs DeclareChoice(string choice)
        {
            Rock_Paper_Scissors.Objs returnedObj = Rock_Paper_Scissors.Objs.scissors;
            switch (choice)
            {
                case "rock":
                    returnedObj = Rock_Paper_Scissors.Objs.rock;
                    break;
                case "paper":
                    returnedObj = Rock_Paper_Scissors.Objs.paper;
                    break;
                case "scissors":
                    returnedObj = Rock_Paper_Scissors.Objs.scissors;
                    break;
            }
            return returnedObj;
        }

        void CheckWinner(Rock_Paper_Scissors.Objs player, Rock_Paper_Scissors.Objs computer)
        {
            if (player == computer)
            {
                //draw - round needs replayed
                do
                {
                    DeclareResult(player, computer);
                    PlayerPick();
                    ComputerPick();

                    //update arguements
                    player = playerObj;
                    computer = comObj;
                } while (player == computer);
                
            }

            switch (player)
            {
                case Rock_Paper_Scissors.Objs.rock:
                    if (computer == Rock_Paper_Scissors.Objs.paper)
                    {
                        //player wins
                        DeclareResult(player, computer);
                    }
                    if (computer == Rock_Paper_Scissors.Objs.scissors)
                    {
                        //computer wins
                        DeclareResult(player, computer);
                    }
                    break;
                case Rock_Paper_Scissors.Objs.paper:
                    if (computer == Rock_Paper_Scissors.Objs.rock)
                    {
                        //player wins
                        DeclareResult(player, computer);
                    }
                    if (computer == Rock_Paper_Scissors.Objs.scissors)
                    {
                        //computer wins
                        DeclareResult(player, computer);
                    }
                    break;
                case Rock_Paper_Scissors.Objs.scissors:
                    if (computer == Rock_Paper_Scissors.Objs.paper)
                    {
                        //player wins
                        DeclareResult(player, computer);
                    }
                    if (computer == Rock_Paper_Scissors.Objs.rock)
                    {
                        //computer wins
                        DeclareResult(player, computer);
                    }
                    break;
            }
        }

        void DeclareResult(Rock_Paper_Scissors.Objs player, Rock_Paper_Scissors.Objs com)
        {
            if (player == com)
            {
                Console.WriteLine($"Draw - both picked {player}! \n");
            }

            switch (player)
            {
                case Rock_Paper_Scissors.Objs.rock:
                    if (com == Rock_Paper_Scissors.Objs.scissors)
                    {
                        //player wins
                        PlayerWins(player, com);
                    }
                    if (com == Rock_Paper_Scissors.Objs.paper)
                    {
                        //com wins
                        ComputerWins(player, com);
                    }
                    break;

                case Rock_Paper_Scissors.Objs.paper:
                    if (com == Rock_Paper_Scissors.Objs.rock)
                    {
                        //player wins
                        PlayerWins(player, com);
                    }
                    if (com == Rock_Paper_Scissors.Objs.scissors)
                    {
                        //com wins
                        ComputerWins(player, com);
                    }
                    break;

                case Rock_Paper_Scissors.Objs.scissors:
                    if (com == Rock_Paper_Scissors.Objs.paper)
                    {
                        //player wins
                        PlayerWins(player, com);
                    }
                    if (com == Rock_Paper_Scissors.Objs.rock)
                    {
                        //com wins
                        ComputerWins(player, com);
                    }
                    break;
            }

            void PlayerWins(Rock_Paper_Scissors.Objs player, Rock_Paper_Scissors.Objs computer)
            {
                Console.WriteLine($"Player Wins - {player} beats {computer}!");
                PlayerWinsNumber++;
            }

            void ComputerWins(Rock_Paper_Scissors.Objs player, Rock_Paper_Scissors.Objs computer)
            {
                Console.WriteLine($"Computer Wins - {computer} beats {player}!" );
                CompWinsNumber++;
            }

        }
        public void DisplayResults()
        {
            Console.WriteLine($"\nPlayer Score: {PlayerWinsNumber}     Computer Score: {CompWinsNumber}");
        }
    }
}
