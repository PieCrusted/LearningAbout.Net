namespace Assignment1;

public class FizzBuzz {
    // Note change from main to Main to select which runs
    public static void main(string[] args) {
        PrintFizzBuzz(100);
    }
    
    static void PrintFizzBuzz(int max) {
        for (int i = 1; i <= max; ++i) {
            Console.Write(i + "   ");

            if (i % 3 == 0) {
                Console.Write("fizz");
            }
            if (i % 5 == 0) {
                Console.Write("buzz");
            }
            
            Console.WriteLine();
        }
    }
}