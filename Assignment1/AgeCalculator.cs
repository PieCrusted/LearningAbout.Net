namespace Assignment1;

public class AgeCalculator {
    public static void main(string[] args) {
        PromptAgeCalc();
    }

    static void PromptAgeCalc() {
        int birthYear, birthMonth, birthDay;

            // Year
            Console.Write("Enter your birth year (YYYY): ");
            // For now hardcoding the max birth year to 2024
            while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 0 || birthYear > 2024) {
                Console.WriteLine("Invalid input. Please enter a valid year (YYYY):");
            }


            // Month
            Console.Write("Enter your birth month (MM): ");
            while (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12) {
                Console.WriteLine("Invalid input. Please enter a valid month (1-12):");
            }


            // Day
            Console.Write("Enter your birth day (DD): ");
            while (!int.TryParse(Console.ReadLine(), out birthDay) || birthDay < 1 || birthDay > DateTime.DaysInMonth(birthYear, birthMonth)) {
                  Console.WriteLine("Invalid input. Please enter a valid day (1-31/30/29/28 based on year and month):");
            }

            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);

            // Today's Date
            DateTime today = DateTime.Today;
            
            TimeSpan age = today - birthDate;

            int ageInDays = (int)age.TotalDays;
            Console.WriteLine($"You are {ageInDays} days old.");

            // 10,000 day anniversary
            int daysToNextAnniversary = 10000 - (ageInDays % 10000);
            DateTime nextAnniversaryDate = today.AddDays(daysToNextAnniversary);

            Console.WriteLine($"Your next 10,000-day anniversary is on {nextAnniversaryDate:d}.");
    }
}