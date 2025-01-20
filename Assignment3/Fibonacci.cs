namespace Assignment3;

public class Fibonacci {
    // Cache for frequent calculations
    private static Dictionary<long, long> cache = new Dictionary<long, long>();

    public static long Fibo(long seq) {
        // Error cases
        if (seq < 0) {
            return -1L;
        }

        // Base case
        if (seq == 1 || seq == 2) {
            return 1L;
        }

        if (cache.ContainsKey(seq)) {
            return cache.GetValueOrDefault(seq);
        }

        long val = Fibo(seq - 1) + Fibo(seq - 2);
        cache.Add(seq, val);
        return val;
    }
}