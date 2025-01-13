namespace Assignment1;

public class IncrementCounter {
    public static void Main(string[] args) {
        Counter(24, 4);
    }

    static void Counter(int max, int range) {
        for (int increment = 1; increment <= range; increment++) {
            Console.Write($"Counting by {increment}: ");
            for (int number = 0; number <= max; number += increment) {
                Console.Write($"{number},");
            }

            Console.WriteLine();
        }
    }
}