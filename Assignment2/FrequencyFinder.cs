namespace Assignment2;

public class FrequencyFinder {
    // In Java I would use a linkedhashmap to save the leftmost, but it looks like 
    // C# Uses a Dictionary
    public static void FindAndPrintMostFrequentNumber(string input) {
        int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
        if (numbers == null || numbers.Length == 0) {
            Console.WriteLine("Input sequence is empty");
            return;
        }
        
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        foreach (int number in numbers) {
            if (frequencyMap.ContainsKey(number)) {
                frequencyMap[number]++;
            }
            else {
                frequencyMap[number] = 1;
            }
        }

        int maxFrequency = 0;
        List<int> maxFreqNumbers = new List<int>();
        int leftmostMaxFreqNumber = 0;

        foreach (var item in frequencyMap) {
            if (item.Value > maxFrequency) {
                maxFrequency = item.Value;
                maxFreqNumbers.Clear(); // Clear the list because we have a new max
                maxFreqNumbers.Add(item.Key); // Add the new number
                leftmostMaxFreqNumber = item.Key;
            }
            else if (item.Value == maxFrequency) {
                maxFreqNumbers.Add(item.Key); // Add to the existing list
            }
        }

        if (maxFreqNumbers.Count == 1) {
            Console.WriteLine($"The number {leftmostMaxFreqNumber} is the most frequent (occurs {maxFrequency} times)");
        }
        else {
            string numbersWithMaxFreqString = string.Join(", ", maxFreqNumbers);
            Console.WriteLine(
                $"The numbers {numbersWithMaxFreqString} have the same maximal frequence (each occurs {maxFrequency} times). The leftmost of them is {leftmostMaxFreqNumber}.");
        }
    }
}