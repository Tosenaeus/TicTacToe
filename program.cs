namespace TicTacToe
{
    internal class Program
    {
        static string[,] matrix =
        {
            {"1" ,"2" ,"3" },
            {"4" ,"5" ,"6" },
            {"7" ,"8" ,"9" }
        };

        static int activePlayer = 1;
        static int inputInt;
        static bool hasWinner = false;
        static void Main(string[] args)
        {
            string controlInput;
            bool run = true;
            do
            {
                GameLoop();

                Console.Write("Game finished. Enter 'Q' to quit, or press any other key to restart: ");
                controlInput = Console.ReadLine();
                if (controlInput.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    run = false;
                } else
                {
                    matrix[0, 0] = "1";
                    matrix[0, 1] = "2";
                    matrix[0, 2] = "3";
                    matrix[1, 0] = "4";
                    matrix[1, 1] = "5";
                    matrix[1, 2] = "6";
                    matrix[2, 0] = "7";
                    matrix[2, 1] = "8";
                    matrix[2, 2] = "9";
                    activePlayer = 1;
                    hasWinner = false;
                }

            } while (run);
        }

        static void GameLoop()
        {
            bool validInput;
            string input;
            int rounds = 0;

            do
            {
                validInput = false;
                Console.Clear();
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  " + matrix[0, 0] + "  |  " + matrix[0, 1] + "  |  " + matrix[0, 2] + "  ");
                Console.WriteLine("_____|_____|_____");
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  " + matrix[1, 0] + "  |  " + matrix[1, 1] + "  |  " + matrix[1, 2] + "  ");
                Console.WriteLine("_____|_____|_____");
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  " + matrix[2, 0] + "  |  " + matrix[2, 1] + "  |  " + matrix[2, 2] + "  ");
                Console.WriteLine("     |     |     ");


                do
                {
                    Console.Write("Player " + activePlayer + ": Choose your field: ");
                    input = Console.ReadLine();

                    if (!int.TryParse(input, out inputInt) || inputInt < 1 || inputInt > 9)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 9");
                    }
                    else
                    {
                        if (MarkField(inputInt))
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Field already taken.");
                        }
                    }
                } while (!validInput);

                hasWinner = CheckWinner(matrix);
                
                if (hasWinner)
                {
                    Console.WriteLine("Player " + activePlayer + " won!");
                }

                rounds++;
                if (rounds == 9 && !hasWinner)
                {
                    Console.WriteLine("No winner!");
                    break;
                }                

                SwitchPlayer();
            } while (!hasWinner);
        }


        static void SwitchPlayer()
        {
            if (activePlayer == 1)
            {
                activePlayer = 2;
            } else
            {
                activePlayer = 1;
            }
        }

        static bool MarkField(int field)
        {
            int parsedField;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int.TryParse(matrix[i, j], out parsedField);
                    if (parsedField == field)
                    {
                        if (activePlayer == 1)
                        {
                            matrix[i, j] = "O";
                        } else
                        {
                            matrix[i, j] = "X";
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        static bool CheckWinner(string[,] board)
        {
            //horizontal
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                {
                    return true;
                }
            }

            //vertical
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == board[1, j] && board[0, j] == board[2, j])
                {
                    return true;
                }
            }

            //diagonal
            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]))
            {
                return true;
            }

            return false;
        }
    }
}
