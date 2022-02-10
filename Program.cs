// Welcome message 
Console.WriteLine("      **Welcome to Nerdle**");
Console.WriteLine("      ---------------------\n");

// Setting 3 random ints 0-9
Random _random1 = new Random();
int firstDigit = _random1.Next(0, 10);

Random _random2 = new Random();
int secondDigit = _random2.Next(0, 10);

Random _random3 = new Random();
int thirdDigit = _random3.Next(0, 10);
// Putting the 3 ints into an array and printing
// For internal purposes only, so we can see the number when testing
// int[] correctAnswer = new int[3] { firstDigit, secondDigit, thirdDigit };

// foreach (int digit in correctAnswer)
// {
//     Console.Write(digit.ToString());
// }

// For Loop that provides 5 attempts
int attempts = 6;
int guessResult = 0;
for (int i = 0; i < attempts && guessResult == 0; i++)
{
    if (i == 5)
    {
        guessResult = 0;
        Console.WriteLine("~ You have run out of attempts. Better luck next time. ~");
    }
    else
    {
        Console.Write($"Try to guess our 3 digit number. You have {attempts - (i + 1)} attempts left:  ");
        string input = Console.ReadLine();

        //Check entered value to confirm it is 3 digits and does not contain other character types
        int number;
        bool isValid = int.TryParse(input, out number);
        char[] inputArray = input.ToCharArray();
        int digitCheck = inputArray.GetLength(0);
        
        if (!isValid || digitCheck != 3)
        {
            Console.WriteLine("~ Sorry, that was not a valid guess. ~");
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
                guessResult = 1;
                Console.WriteLine("*Congratulations! You correctly guessed our number. You are a Nerdle.*\n");
            }

            else
            {
                string feedback1 = firstDigit == guessDigit1 ? "correct" : firstDigit > guessDigit1 ? "higher" : "lower";
                Console.WriteLine($"The first digit is {feedback1}. ");

                string feedback2 = secondDigit == guessDigit2 ? "correct" : secondDigit > guessDigit2 ? "higher" : "lower";
                Console.WriteLine($"The second digit is {feedback2}. ");

                string feedback3 = thirdDigit == guessDigit3 ? "correct" : thirdDigit > guessDigit3 ? "higher" : "lower";
                Console.WriteLine($"The third digit is {feedback3}. ");
            }
        }
    }
}
// Add some color? Make Congratulations green and error messages red?
//    Fancy title? |\  |
//                 | \ |
//                 |  \|



