using System.Xml.Schema;

namespace DiceGame
{
    internal class Program
    {
        static Random rnd = new Random();
        static int dice1Num, dice2Num, humanFinalScore, computerFinalScore;
        static bool keepPlaying = true;
        static bool keepAskingforCorrectInput = true;

        static void Main(string[] args)
        {
            while (keepPlaying)
            {
                PlayerRollDice("Human");

                Console.WriteLine("Press any key");
                Console.ReadKey();
                Console.WriteLine();

                PlayerRollDice("Computer");
                CompareScoresAndShowResult();

                while (keepAskingforCorrectInput) 
                {
                    PromptToPlayAgain();
                }

                //Setting keepAskingforCorrectInput to true to enter the while loop above in the next game session
                keepAskingforCorrectInput = true;
            }
        }

        //Method for rolling the dice for the 2 different players
        static void PlayerRollDice(string player)
        {
            switch (player)
            {
                case "Human": 
                        humanFinalScore = RollTwoDice();
                        Console.WriteLine("Your turn");
                        Console.WriteLine("You rolled a " + dice1Num + " and a " + dice2Num);
                        Console.WriteLine("Total is " + humanFinalScore);
                    break;

                case "Computer":
                        computerFinalScore = RollTwoDice();
                        Console.WriteLine("Computer's turn");
                        Console.WriteLine("Computer rolled a " + dice1Num + " and a " + dice2Num);
                        Console.WriteLine("Total is " + computerFinalScore);
                    break;
            }
        }

        //Method for generating two different random numbers
        static int RollTwoDice()
        {
            dice1Num = rnd.Next(1, 7);
            dice2Num = rnd.Next(1, 7);
            int score = dice1Num + dice2Num;
            return score;
        }


        //Comparing final scores of player and computer
        static void CompareScoresAndShowResult()
        {
            if (humanFinalScore > computerFinalScore)
            {
                Console.WriteLine("You won! :)\n\n");
            }

            else if (humanFinalScore < computerFinalScore) 
            {
                Console.WriteLine("You lost! :(\n\n");
            }
            else 
            {
                Console.WriteLine("It's a draw! :|\n\n");
            }
        }

        //Asking player if they wish to play again
        static void PromptToPlayAgain()
        {
            Console.WriteLine("Play again? Y or N");
            var userInput = Console.ReadKey();
            Console.WriteLine();

                switch (userInput.Key)
                {
                    case ConsoleKey.N:
                        keepPlaying = false;
                        keepAskingforCorrectInput = false;
                        Console.WriteLine("Thanks for playing!");
                        Thread.Sleep(2000);
                        break;

                    case ConsoleKey.Y:
                        keepPlaying = true;
                        keepAskingforCorrectInput = false;
                        break;

                    //Handling characters that are not Y and N
                    default:
                        Console.WriteLine("Enter the correct character");
                        //If the user inputs an incorrect character set the bool flag to true and enter the 2nd while loop in main
                        keepAskingforCorrectInput = true;
                        break;
                }
        }
    }
}