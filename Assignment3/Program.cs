namespace Assignment3;

class Program {
    static void Main(string[] args) {
        // Array Reveral Methods
        int[] numbers = ArrayReversalMethods.GenerateNumbers();
        ArrayReversalMethods.PrintNumbers(numbers);
        ArrayReversalMethods.Reverse(numbers);
        ArrayReversalMethods.PrintNumbers(numbers);
        
        // Fibonacci
        int n = 100;
        Console.WriteLine($"The first {n} fibonacci sequence");
        for (int i = 1; i <= 100; i++) {
            Console.Write(Fibonacci.Fibo(i) + " ");
        }
        
    }
}