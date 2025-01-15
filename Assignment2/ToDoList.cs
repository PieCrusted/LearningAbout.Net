namespace Assignment2;

public class ToDoList {
    public static void Demonstration() {
        List<string> itemList = new List<string>();

        while (true) {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)) End with Ctrl + C");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Invalid Input!");
                continue;
            }

            // I've always put else if directly after the last braces, but I think I now prefer doing
            // a line skip
            if (input.StartsWith("+ ")) {
                string itemToAdd = input.Substring(2);
                itemList.Add(itemToAdd);
                Console.WriteLine($"Added: {itemToAdd}");
            }
            else if (input.StartsWith("- ")) {
                string itemToRemove = input.Substring(2);

                if (itemList.Contains(itemToRemove)) {
                    itemList.Remove(itemToRemove);
                    Console.WriteLine($"Removed: {itemToRemove}");
                }
                else {
                    Console.WriteLine("Item not in the list!");
                }
            }
            else if (input == "--") {
                itemList.Clear();
                Console.WriteLine("List cleared");
            }
            else {
                Console.WriteLine("Invalid command!");
            }

            // Display current list
            Console.WriteLine("Current List:");
            if (itemList.Any()) {
                foreach (var item in itemList) {
                    Console.WriteLine($"- {item}");
                }
            }
            else {
                Console.WriteLine("List is empty!");
            }
        }
    }
}