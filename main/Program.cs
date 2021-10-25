using System;

namespace HelloWorld
{
    public class Program
    {
        public static String playerOneName;
        public static String playerTwoName;
        public static bool isGameOn = false;
        public static bool turnPlayerOne = true;
        public static int turnsCount = 0;
        public static int gameStatus = 0; //Zero = draw, 1 = Player one won, 2 = player 2 won, 3 = still playing
        private static String[] gameSpots = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        static void Main(string[] args)
        {
            //Infitine loop for the game
            while (true)
            {
                String spaceSelectedChar;
                int spaceSelected;
                //Go to main menu only if there isn't an ongoing game
                if (isGameOn == false)
                {
                    MainMenu();
                }
                //On-going game is here
                if (isGameOn == true)
                {
                    //Check the status of the game for any winners or draws
                    if (gameStatus == 0)
                    {
                        Console.Write($"{Environment.NewLine}The game has ended in a DRAW. Thanks for playing! ");
                        Console.ReadKey(true);
                        ResetGame();
                    }
                    if (gameStatus == 1)
                    {
                        Console.Write($"{Environment.NewLine}{playerOneName} has WON! Thanks for playing! ");
                        Console.ReadKey(true);
                        ResetGame();
                    }
                    if (gameStatus == 2)
                    {
                        Console.Write($"{Environment.NewLine}{playerTwoName} has WON! Thanks for playing! ");
                        Console.ReadKey(true);
                        ResetGame();
                    }
                    //If nobody has won then continue with the next turn
                    if (gameStatus == 3)
                    {
                        //This is the main game play logic
                        if (turnPlayerOne == true)
                        {
                            Console.Write($"{Environment.NewLine}It is {playerOneName} ('X') turn.");
                        }
                        else
                        {
                            Console.Write($"{Environment.NewLine}It is {playerTwoName} ('O') turn.");

                        }
                        Console.Write($"{Environment.NewLine}Enter the number of the space where you want to play: ");
                        spaceSelectedChar = Console.ReadKey(true).KeyChar.ToString();
                        bool success = int.TryParse(spaceSelectedChar, out spaceSelected);
                        if (success == true)
                        {
                            if (gameSpots[spaceSelected - 1] == "O" || gameSpots[spaceSelected - 1] == "X")
                            {
                                Console.Write($"{Environment.NewLine} That space is already occupied. Try again. (press any key to continue)");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                turnsCount++;

                                if (turnPlayerOne == true)
                                {
                                    gameSpots[spaceSelected - 1] = "X";
                                    DrawBoard();
                                    gameStatus = EvaluateGame("X");
                                    turnPlayerOne = false;
                                }
                                else
                                {
                                    gameSpots[spaceSelected - 1] = "O";
                                    DrawBoard();
                                    gameStatus = EvaluateGame("O");
                                    turnPlayerOne = true;
                                }

                            }

                        }
                    }


                }
                else
                {
                    Console.Write($"{Environment.NewLine}Press any key to play again. Press 'X' to exit...");
                    char chr = Console.ReadKey(true).KeyChar;
                    if (char.ToUpper(chr) == 'X')
                        break;
                }
            }
        }

        private static void ResetGame()
        {
            isGameOn = false;
            turnPlayerOne = true;
            turnsCount = 0;
            gameStatus = 0; //Zero = draw, 1 = Player one won, 2 = player 2 won, 3 = still playing
            gameSpots = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        }
        private static void MainMenu()
        {
            Console.Clear();
            Console.Write($"{Environment.NewLine}Welcome to TIC-TAC-TOE");
            Console.Write($"{Environment.NewLine}");
            Console.Write($"{Environment.NewLine}Are you ready to play? (y/n)");
            char chr = Console.ReadKey(true).KeyChar;
            if (char.ToUpper(chr) == 'N')
                return;
            Console.Clear();
            Console.Write($"{Environment.NewLine}Enter the name of the player ONE ('X'): ");
            playerOneName = Console.ReadLine();
            Console.Write($"{Environment.NewLine}Enter the name of the player TWO ('O'): ");
            playerTwoName = Console.ReadLine();
            Console.Write($"{Environment.NewLine}Thanks, the game will begin after you press any key...");
            Console.ReadKey(true);
            isGameOn = true;
            gameStatus = 3;
            DrawBoard();
        }

        private static int EvaluateGame(String symbolChecking)
        {
            //Zero = draw, 1 = Player one won, 2 = player 2 won, 3 = still playing

            if (turnsCount >= 9)
                return 0;
            //Check 1st row
            if (gameSpots[0] == symbolChecking && gameSpots[1] == symbolChecking && gameSpots[2] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;
            //Check 2nd row
            if (gameSpots[3] == symbolChecking && gameSpots[4] == symbolChecking && gameSpots[5] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;
            //Check 3rd row
            if (gameSpots[6] == symbolChecking && gameSpots[7] == symbolChecking && gameSpots[8] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;
            //Check 1st column
            if (gameSpots[0] == symbolChecking && gameSpots[3] == symbolChecking && gameSpots[6] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;
            //Check 2nd column
            if (gameSpots[1] == symbolChecking && gameSpots[4] == symbolChecking && gameSpots[7] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;
            //Check 3rd column
            if (gameSpots[2] == symbolChecking && gameSpots[5] == symbolChecking && gameSpots[8] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;
            //Check 1st diagonal
            if (gameSpots[0] == symbolChecking && gameSpots[4] == symbolChecking && gameSpots[8] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;
            //Check 2nd diagonal
            if (gameSpots[2] == symbolChecking && gameSpots[4] == symbolChecking && gameSpots[6] == symbolChecking)
                if (symbolChecking == "X")
                    return 1;
                else return 2;

            return 3;
        }

        public static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("		│    │   		│    │");
            Console.WriteLine("		│    │   		│    │");
            Console.WriteLine($"             {gameSpots[0]}  │ {gameSpots[1]}  │  {gameSpots[2]}            1  │ 2  │  3");
            Console.WriteLine("		│    │   		│    │");
            Console.WriteLine("         ───────┼────┼────────   ───────┼────┼────────");
            Console.WriteLine("		│    │   		│    │");
            Console.WriteLine($"             {gameSpots[3]}  │ {gameSpots[4]}  │  {gameSpots[5]}            4  │ 5  │  6");
            Console.WriteLine("		│    │   		│    │");
            Console.WriteLine("         ───────┼────┼────────   ───────┼────┼────────");
            Console.WriteLine("		│    │   		│    │");
            Console.WriteLine($"             {gameSpots[6]}  │ {gameSpots[7]}  │  {gameSpots[8]}            7  │ 8  │  9");
            Console.WriteLine("		│    │   		│    │");




        }

    }
}
