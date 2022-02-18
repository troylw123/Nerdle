using Nerdle;

Introduction intro = new Introduction();
NerdleGenerator nerdGen = new NerdleGenerator();

// Welcome message 
intro.WelcomeMessage();
// Setting 3 random ints 0-9

int firstDigit = nerdGen.GenerateNerdle();
int secondDigit = nerdGen.GenerateNerdle();
int thirdDigit = nerdGen.GenerateNerdle();

int score = 0;
int attemptsGranted = 0;
// For internal purposes only, so we can see the number when testing
// Console.Write($"{firstDigit}{secondDigit}{thirdDigit}");
string game = "on";
while (game == "on")
{
// While loop that prompts # of attempts requested, throws error message if not a # 1 through 6
int attempts = 0;
while (attempts == 0) 
{
    Console.WriteLine("How many attempts do you need to guess our number? ");
    Console.Write("Choose # of attempts, 1 through 6: ");
    string attemptsRequested = (Console.ReadLine()!);
    
    bool isInteger = int.TryParse(attemptsRequested, out attemptsGranted);
if (attemptsGranted > 0 && attemptsGranted <= 6 && isInteger == true)
    {
       attempts += attemptsGranted;
    }
else
{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~ Sorry, that was not a # 1 through 6. ~");
            Console.ResetColor();
}
}
// For Loop that provides requested # attempts

for (int i = 0; i <= attempts && game == "on"; i++)
{
    if (i == attempts)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n~ You have run out of attempts. Better luck next time. ~\n");
        Console.ResetColor();
        score-=100;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"    << Your current score is:  {score} >>\n");
        Console.ResetColor();
        PromptNewGame();
    }
    else
    {
        Console.Write($"\nTry to guess our 3 digit number. You have {attempts - (i)} attempts left:  ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        string input = Console.ReadLine()!;
        Console.ResetColor();
        //Check entered value to confirm it is 3 digits and does not contain other character types
        int number;
        bool isValid = int.TryParse(input, out number);
        char[] inputArray = input.ToCharArray();
        int digitCheck = inputArray.GetLength(0);
        
        if (!isValid || digitCheck != 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~ Sorry, that was not a valid guess. ~");
            Console.ResetColor();
            i--;
        }
        else
        {

            // Takes the user input, converts to array of char, then array of int, then 3 single digit ints
            char[] guess = input.ToCharArray();
            int guessDigit1 = int.Parse(guess[0].ToString());
            int guessDigit2 = int.Parse(guess[1].ToString());
            int guessDigit3 = int.Parse(guess[2].ToString());

            // Conditional that compares user guess to our random ints and provides feedback
            if (firstDigit == guessDigit1 && secondDigit == guessDigit2 && thirdDigit == guessDigit3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n** Congratulations! You correctly guessed our number. You are a Nerdle! **\n");
                Console.ResetColor();
                AddToScore(attemptsGranted);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"    << Your current score is:  {score} >>\n");
                Console.ResetColor();
                PromptNewGame();
                break;
            }

            else
            {
                // string feedback1 = firstDigit == guessDigit1 ? "correct" : firstDigit > guessDigit1 ? "higher" : "lower";
                // Console.Write($"The first digit is {feedback1}. |  ");

                // string feedback2 = secondDigit == guessDigit2 ? "correct" : secondDigit > guessDigit2 ? "higher" : "lower";
                // Console.Write($"The second digit is {feedback2}. |  ");

                // string feedback3 = thirdDigit == guessDigit3 ? "correct" : thirdDigit > guessDigit3 ? "higher" : "lower";
                // Console.WriteLine($"The third digit is {feedback3}. ");

                Console.Write($"\n     First digit is ");
                CompareNumbers(firstDigit, guessDigit1);
                Console.Write($"  |  Second digit is ");
                CompareNumbers(secondDigit, guessDigit2);
                Console.Write($"  |  Third digit is ");
                CompareNumbers(thirdDigit, guessDigit3);
                Console.WriteLine("");
            }
        }
    }
}
}

// Method that prompts starts a new game or ends the program
void PromptNewGame()
{
    Console.Write("Would you like to play again? Y or N? ");
    string response = Console.ReadLine()!;
    if (response != "Y" && response != "y")
    {
        game = "off";
    }
    else
    {   
        firstDigit = nerdGen.GenerateNerdle();
        secondDigit = nerdGen.GenerateNerdle();
        thirdDigit = nerdGen.GenerateNerdle();
    }
}

// Method that adds points to your score if you win
int AddToScore(int pointsEarned)
{
    switch (pointsEarned)
    {
        case 6: return score+=25; 
        case 5: return score+=50; 
        case 4: return score+=100; 
        case 3: return score+=250; 
        case 2: return score+=500; 
        case 1: return score+=1000;
        default: return score+=0;
    }
    
}
// Compares each digit guessed to the random digit and provides appropriately colored feedback
void CompareNumbers(int randomNum, int inputNum)
{
    if (inputNum == randomNum)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("correct");
        Console.ResetColor();
    }
    else if (inputNum > randomNum)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("lower");
        Console.ResetColor();
    }
    else 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("higher");
        Console.ResetColor();
    }
}

namespace Nerdle
{
    public class Introduction {
        //public string name;
        
        public void WelcomeMessage()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"                        ___   __    __         ___");
                Console.WriteLine(@"    ----------   |\  | |     |__)  |  \  |    |   ");
                Console.WriteLine(@"    WELCOME TO   | \ | |--   | \   |   | |    |-- ");
                Console.WriteLine(@"    ----------   |  \| |___  |  \  |__/  |___ |___");
                Console.WriteLine("");
                Console.WriteLine("You must guess our 3 digit number. After each attempt, we will tell you if each digit is higher, lower, or correct.");
                Console.WriteLine("If you guess all 3 digits correctly, you will be awarded points based on the # of attempts you have chosen.");
                Console.ResetColor();
                Console.WriteLine("\n 6 attempts = 25 points \n 5 attempts = 50 points \n 4 attempts = 100 points \n 3 attempts = 250 points \n 2 attempts = 500 points \n 1 attempt = 1000 points\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Should you run out of attempts before correctly guessing all 3 digits, you will lose 100 points. Good luck!\n");
                Console.ResetColor();
            }
    }
    public class NerdleGenerator
    {
        public int GenerateNerdle()
        {
            Random _random = new Random();
            int digit = _random.Next(0, 10);
            return digit;
        }
    }
}
