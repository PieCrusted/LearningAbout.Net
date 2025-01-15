namespace Assignment2;

class Program {
    // Will use this main method to execute all programs
    static void Main(string[] args) {
        // // Copying an Array
        // int[] originalArray = new int[10];
        // for (int i = 0; i < originalArray.Length; i++) {
        //     // Elements are twice the index
        //     originalArray[i] = i * 2;
        // }
        // CopyArray.Demonstration(originalArray);
        
        // // To Do List
        // ToDoList.Demonstration();
        
        // // FInding Primes
        // int[] primes = FindPrimes.FindPrimesInRange(10, 100);
        // PrintArray(primes);
        
        // // Array Rotation
        // ArrayRotation.RotateAndSumDemonstration("5 3 1 2 3 4 5");
        
        // // Longest Sequence
        // Console.WriteLine("Input: 2 1 1 2 3 3 2 2 2 1");
        // LongestSequence.FindAndPrintLongestSequence("2 1 1 2 3 3 2 2 2 1");
        
        // // Most Frequent Number
        // FrequencyFinder.FindAndPrintMostFrequentNumber("4 1 1 4 2 3 4 4 1 2 4 9 3");
        // FrequencyFinder.FindAndPrintMostFrequentNumber("7 7 7 0 2 2 2 0 10 10 10");
        
        // // String reversal 2 ways
        // ReverseString.ReverseStringUsingCharArray("sample");
        // ReverseString.ReverseStringUsingForLoop("24tvcoi92");
        
        // // Setence Reverser while Preserving punctuation
        // SentenceReverser.ReverseWords("C# is not C++, and PHP is not Delphi!");
        
        // // Find Palindromes
        // Console.WriteLine("Input: Hi,exe? ABBA! Hog fully a string: ExE. Bob");
        // PalindromeFinder.ExtractPalindromes("Hi,exe? ABBA! Hog fully a string: ExE. Bob");
        
        // URL Parsing
        URLParser.ParseUrl("https://www.apple.com/iphone");
        URLParser.ParseUrl("https://google.com");
    }
    
    static void PrintArray(int[] array) {
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}