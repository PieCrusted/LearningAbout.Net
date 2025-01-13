namespace Assignment1;

public class Pyramid {
    public static void main(string[] args) {
        PrintPyramid(10);
    }
    
    static void PrintPyramid(int height) {
        for (int i = 1; i <= height; ++i) {
            // Spaces construction
            for (int j = 0; j < height - i; ++j) {
                Console.Write(" ");
            }
            
            // Stars Construction
            int starCalc = (i == 1) ? 1 : i * 2 - 1;
            for (int k = 0; k < starCalc; ++k) {
                Console.Write("*");
            }
            
            Console.WriteLine();
        }
    }
}