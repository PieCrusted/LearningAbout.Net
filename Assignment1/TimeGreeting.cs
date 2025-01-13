namespace Assignment1;

public class TimeGreeting {
    public static void main(string[] args) {
        Greet();
    }

    static void Greet() {
        DateTime currentTime = DateTime.Now;

        int hour = currentTime.Hour;

        string greeting = "";
        
        if (hour >= 6 && hour < 12) {
            greeting = "Good Morning";
        } else if (hour >= 12 && hour < 17) {
            greeting = "Good Afternoon";
        } else if(hour >= 17 && hour < 22) {
            greeting = "Good Evening";
        } else if(hour >=22 || hour < 6) {
            greeting = "Good Night";
        }

        Console.WriteLine($"{greeting}!");
    }
}