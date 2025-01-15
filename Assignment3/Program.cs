namespace Assignment3;

class Program {
    static void Main(string[] args) {
        // Array Reveral Methods
        int[] numbers = ArrayReversalMethods.GenerateNumbers();
        ArrayReversalMethods.PrintNumbers(numbers);
        ArrayReversalMethods.Reverse(numbers);
        ArrayReversalMethods.PrintNumbers(numbers);
        
    }
}