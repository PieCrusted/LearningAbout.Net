namespace Assignment1;

public class GuessingGame {
    // Note change from main to Main to select which runs
    public static void main(string[] args) {
        PrintGuessingGame(3);
    }
    
    static void PrintGuessingGame(int range) {
        int correctNumber = new Random().Next(range) + 1;
        
        Console.WriteLine("Guessing Game!");
        
        Console.Write("Enter a guess: ");

        while (true) {
            if (int.TryParse(Console.ReadLine(), out int guess)) {
                // Congratulatory statement
                if (guess == correctNumber) {
                    Console.WriteLine("Congratuslation you guessed the correct number of: " + guess + "!");
                    return;
                }
            
                // low, high, outside range
                if (guess < correctNumber) {
                    Console.WriteLine("Too low!");
                    continue;
                }

                if (guess > correctNumber && guess > range) {
                    Console.WriteLine("Your guess is outside the range");
                    continue;
                }
                
                Console.WriteLine("Too high!");
            } else {
                Console.WriteLine("Invalid input. Please enter a valid number");
            }
        }
    }
}