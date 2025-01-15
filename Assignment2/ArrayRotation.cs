namespace Assignment2;

public class ArrayRotation {
    public static void RotateAndSumDemonstration(string str) {
        // Convert string into int[]
        string[] input = str.Split(' ');
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int[] array = input.Skip(2).Select(int.Parse).ToArray();

        // Output the initial settings
        Console.WriteLine($"Managing an array of size {n} and rotating by {k} for the array below:");
        PrintArray(array);


        // Check for length check
        if (array.Length != n) {
            Console.WriteLine($"Invalid input. Please provide {n} integers separated by space after n and k.");
            return;
        }

        int[] sum = new int[n];

        for (int r = 1; r <= k; r++) {
            // Create a new rotated array in each rotation
            int[] rotatedArray = new int[n];

            for (int i = 0; i < n; i++) {
                int newPosition = (i + r) % n;
                rotatedArray[newPosition] = array[i];
                sum[newPosition] += rotatedArray[newPosition];
            }

            // Show the rotations
            Console.WriteLine($"rotated{r}[] = {string.Join(" ", rotatedArray)}");
        }

        // Output the sum array
        Console.WriteLine(string.Join(" ", sum));
    }

    static void PrintArray(int[] array) {
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}