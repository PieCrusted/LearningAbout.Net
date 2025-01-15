using System.Text;

namespace Assignment2;

public class SentenceReverser {
    public static void ReverseWords(string sentence) {
        if (string.IsNullOrEmpty(sentence)) {
            return;
        }

        List<string> words = new List<string>();
        StringBuilder currentWord = new StringBuilder();

        foreach (char c in sentence) {
            if (char.IsLetterOrDigit(c) || c == '+') {
                currentWord.Append(c);
            }
            else {
                if (currentWord.Length > 0) {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }

                words.Add(c.ToString());
            }
        }

        if (currentWord.Length > 0) {
            words.Add(currentWord.ToString());
        }

        words.Reverse();

        Console.WriteLine("Input: " + sentence);
        Console.WriteLine("Reversed Sentence: " + string.Join("", words));
    }
}