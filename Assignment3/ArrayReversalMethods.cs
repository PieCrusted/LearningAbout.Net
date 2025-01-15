namespace Assignment3;

public class ArrayReversalMethods {
    public static int[] GenerateNumbers(int length = 10, int min = 1, int max = 100) {
        if (length <= 0) {
            return new int[0];
        }

        Random random = new Random();
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++) {
            numbers[i] = random.Next(min, max + 1);
        }

        return numbers;
    }

    public static void Reverse(int[] array) {
        if (array.Equals(null) || array.Length <= 1) {
            return;
        }

        int left = 0;
        int right = array.Length - 1;
        while (left < right) {
            // Rider suggested swapping through deconstruction
            (array[left], array[right]) = (array[right], array[left]);
            left++;
            right--;
        }
    }

    public static void PrintNumbers(int[] array) {
        if (array.Equals(null)) {
            Console.WriteLine("Array is null!");
            return;
        }

        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}