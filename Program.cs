// Randomly generate 3 digit number
    // random
// Take in user input
    // Console.readline
// Compare digits
    // using FOREACH() 
// Provide feedback
    // if statements
// Repeat for 6 turns (if needed)
    // use a loop?
// Display end result

Random _random1 = new Random();
int firstDigit = _random1.Next(0,10);

Random _random2 = new Random();
int secondDigit = _random2.Next(0,10);

Random _random3 = new Random();
int thirdDigit = _random3.Next(0,10);

int[] correctAnswer = new int[3]{firstDigit, secondDigit, thirdDigit};

foreach (int digit in correctAnswer)
            {
                Console.Write(digit.ToString());
            }

Console.Write("Try to guess our 3 digit number: ");
string input = Console.ReadLine();
char[] guess = input.ToCharArray();

int guessDigit1 = int.Parse(guess[0].ToString());
int guessDigit2 = int.Parse(guess[1].ToString());
int guessDigit3 = int.Parse(guess[2].ToString());

// if statement for invalid input? guessDigit1, 2, or 3 not an int 0-9?

if (firstDigit == guessDigit1 && secondDigit == guessDigit2 && thirdDigit == guessDigit3)
{
    Console.WriteLine("Congratulations! You correctly guessed our number. You are a Nerdle.");
}
else
{
string feedback1 = firstDigit == guessDigit1 ? "correct" : firstDigit > guessDigit1 ? "higher" : "lower";
Console.Write($"The first digit is {feedback1}. ");

string feedback2 = secondDigit == guessDigit2 ? "correct" : secondDigit > guessDigit2 ? "higher" : "lower";
Console.Write($"The second digit is {feedback2}. ");

string feedback3 = thirdDigit == guessDigit3 ? "correct" : thirdDigit > guessDigit3 ? "higher" : "lower";
Console.WriteLine($"The third digit is {feedback3}. ");
}

// loop lines 29-53 on a counter with 6 attempts
// Console.WriteLine that says you have x attempts remaining?
