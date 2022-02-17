# Nerdle

Game similar to **Wordle**, the popular word guessing game.

Generates a random 3 digit number between 000 and 999. 

The player is asked to guess a 3 digit number. The player then receives feedback on each digit guessed.
Nerdle will tell the player if each digit is correct or if they need to guess higher or lower for that digit.

Player can choose how many attempts they want to guess the number correctly.
If successful, they will receive points based on the number of attempts they chose.

*6 attempts = 25 points*
*5 attempts = 50 points*
*4 attempts = 100 points*
*3 attempts = 250 points*
*2 attempts = 500 points*
*1 attempt = 1000 points*

If unsuccessful, the player will lose 100 points. Score accumulates as long as player keeps playing.

---

A custom error message displays if the player does not enter a 3 digit integer, or does not enter a # 1 through 6 when choosing how many attempts they want.