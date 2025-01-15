namespace Assignment2;

public class LongestSequence {
    public static void FindAndPrintLongestSequence(string str) {
        // Convert string to int array
        int[] array = str.Split(' ').Select(int.Parse).ToArray();
        
        // Manually keep track of stats
        int longestSequenceStart = 0;
        int longestSequenceLength = 0;
        int currentSequenceStart = 0;
        int currentSequenceLength = 1;

        if (array.Length == 0) {
            Console.WriteLine("Empty Array");
            return;
        }
        
        // Note to self: I used always do ++i instead of i++, but thinking about it this way, the compilers
        // should be smart enough to know that the previous i in i++ isn't used, and so it should skip that 
        // instruction in assembly. Maybe for interpreted launguages it might be different, but compiled
        // ones shouldn't be affected. I'll probably alternate between them on if I feel lazy or not.
        for (int i = 1; i < array.Length; i++) {
            if (array[i] == array[i - 1]) {
                currentSequenceLength++;
            }
            else {
                if (currentSequenceLength > longestSequenceLength) {
                    longestSequenceLength = currentSequenceLength;
                    longestSequenceStart = currentSequenceStart;
                }

                currentSequenceStart = i;
                currentSequenceLength = 1;
            }
        }

        // Check for the last sequence after loop finishes
        if (currentSequenceLength > longestSequenceLength) {
            longestSequenceLength = currentSequenceLength;
            longestSequenceStart = currentSequenceStart;
        }


        Console.Write("Output: ");
        for (int i = longestSequenceStart; i < longestSequenceStart + longestSequenceLength; i++) {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}