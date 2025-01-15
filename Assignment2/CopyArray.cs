namespace Assignment2;

public class CopyArray {
    public static void Demonstration(int[] originalArray) {
        int[] copiedArray = new int[originalArray.Length];

        // Copy Values
        copiedArray = (int[])originalArray.Clone();

        // Print
        Console.WriteLine("Original Array:");
        PrintArray(originalArray);

        Console.WriteLine("\nCopied Array:");
        PrintArray(copiedArray);
    }

    static void PrintArray(int[] array) {
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}