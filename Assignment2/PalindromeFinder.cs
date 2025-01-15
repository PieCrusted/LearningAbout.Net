using System.Text.RegularExpressions;

namespace Assignment2;

public class PalindromeFinder {
    public static void ExtractPalindromes(string text) {
        if (string.IsNullOrEmpty(text)) {
            return;
        }

        // Use Regex to extract words
        string[] words = Regex.Split(text, @"\W+").Where(s => !string.IsNullOrEmpty(s)).ToArray();

        SortedSet<string> palindromes = new SortedSet<string>();

        foreach (string word in words) {
            if (IsPalindrome(word)) {
                palindromes.Add(word);
            }
        }


        Console.WriteLine(string.Join(", ", palindromes));
    }


    private static bool IsPalindrome(string word) {
        if (word.Length <= 1) {
            return true;
        }

        int left = 0;
        int right = word.Length - 1;

        while (left < right) {
            if (word[left] != word[right]) {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}