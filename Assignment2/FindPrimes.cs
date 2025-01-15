namespace Assignment2;

public class FindPrimes {
    public static int[] FindPrimesInRange(int startNum, int endNum) {
        // Handle issues
        if (startNum > endNum) {
            return new int[0];
        }
        if (startNum < 2) {
            return new int[0];
        }
        if (endNum < 2) {
            return new int[0];
        }

        // Use arraylist then convert to array
        List<int> primes = new List<int>();

        for (int num = startNum; num <= endNum; ++num) {
            if (IsPrime(num)) {
                primes.Add(num);
            }
        }

        return primes.ToArray();
    }

    private static bool IsPrime(int number) {
        // Special cases
        if (number <= 1)
            return false;
        if (number <= 3)
            return true;
        if (number % 2 == 0 || number % 3 == 0)
            return false;

        for (int i = 5; i * i <= number; ++i) {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}