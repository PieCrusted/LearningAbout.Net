namespace Assignment1;

public class _02UnderstandingTypes {
    // Note change from main to Main to select which runs
    public static void main(string[] args) {
        PrintBar();
        Console.WriteLine("Number Value Type Information: ");
        PrintBar();
        Console.WriteLine("{0,-10} {1,-10} {2,-20} {3,-20}", "Type", "Bytes", "Min Value", "Max Value");
        Console.WriteLine(new string('-', 60));

        PrintTypeInfo("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
        PrintTypeInfo("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
        PrintTypeInfo("short", sizeof(short), short.MinValue, short.MaxValue);
        PrintTypeInfo("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
        PrintTypeInfo("int", sizeof(int), int.MinValue, int.MaxValue);
        PrintTypeInfo("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
        PrintTypeInfo("long", sizeof(long), long.MinValue, long.MaxValue);
        PrintTypeInfo("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
        PrintTypeInfo("float", sizeof(float), float.MinValue, float.MaxValue);
        PrintTypeInfo("double", sizeof(double), double.MinValue, double.MaxValue);
        PrintTypeInfo("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
        
        PromptTime();
    }

    static void PrintBar() {
        Console.WriteLine("========================================================");
    }
    
    static void PrintTypeInfo(string typeName, int size, dynamic minValue, dynamic maxValue) {
        Console.WriteLine("{0,-10} {1,-10} {2,-20} {3,-20}", typeName, size, minValue, maxValue);
    }

    static void PromptTime() {
        PrintBar();
        Console.WriteLine("Time Conversion");
        PrintBar();
        Console.Write("Enter the number of centuries: ");
        
        if (int.TryParse(Console.ReadLine(), out int centuries)) {
            PrintTime(centuries);
        } else {
            Console.WriteLine("Invalid input. Please enter a valid number");
            PromptTime();
        }
    }

    static void PrintTime(int centuries) {
        int years = centuries * 100;
        int days = years * 365;
        long hours = (long)days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        decimal nanoseconds = (decimal)microseconds * 1000;

        Console.WriteLine($"{centuries} centuries = {years} years");
        Console.WriteLine($"{centuries} centuries = {days} days");
        Console.WriteLine($"{centuries} centuries = {hours} hours");
        Console.WriteLine($"{centuries} centuries = {minutes} minutes");
        Console.WriteLine($"{centuries} centuries = {seconds} seconds");
        Console.WriteLine($"{centuries} centuries = {milliseconds} milliseconds");
        Console.WriteLine($"{centuries} centuries = {microseconds} microseconds");
        Console.WriteLine($"{centuries} centuries = {nanoseconds} nanoseconds");
    }
}