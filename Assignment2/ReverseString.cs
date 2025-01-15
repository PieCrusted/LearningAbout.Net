namespace Assignment2;

public class ReverseString {
    public static void ReverseStringUsingCharArray(string input) {
        if (string.IsNullOrEmpty(input)) {
            Console.WriteLine("Input string is null or empty!");
            return;
        }

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversedString = new string(charArray);
        Console.WriteLine($"Reversed String using Char Array: {reversedString}");
    }

    public static void ReverseStringUsingForLoop(string input) {
        if (string.IsNullOrEmpty(input)) {
            Console.WriteLine("Input string is null or empty!");
            return;
        }

        Console.Write("Reversed String using For Loop: ");
        for (int i = input.Length - 1; i >= 0; i--) {
            Console.Write(input[i]);
        }

        Console.WriteLine();
    }
}