namespace Assignment4;

public class MyList<T> {
    private List<T> items;

    public MyList() {
        items = new List<T>();
    }

    public void Add(T element) {
        items.Add(element);
    }

    public int Count() {
        return items.Count;
    }

    // This one returns type while DeleteAt doesn't return
    public T Remove(int index) {
        if (index < 0 || index >= items.Count) {
            throw new ArgumentOutOfRangeException("index", "Index is out of range.");
        }

        T item = items[index];
        items.RemoveAt(index);
        return item;
    }

    public bool Contains(T element) {
        return items.Contains(element);
    }


    public void Clear() {
        items.Clear();
    }

    public void InsertAt(T element, int index) {
        if (index < 0 || index > items.Count) {
            throw new ArgumentOutOfRangeException("index", "Index is out of range.");
        }

        items.Insert(index, element);
    }

    public void DeleteAt(int index) {
        if (index < 0 || index >= items.Count) {
            throw new ArgumentOutOfRangeException("index", "Index is out of range.");
        }

        items.RemoveAt(index);
    }

    public void Delete(T item) {
        items.Remove(item);
    }

    public T Find(int index) {
        if (index < 0 || index >= items.Count) {
            throw new ArgumentOutOfRangeException("index", "Index is out of range.");
        }

        return items[index];
    }

    public void PrintList() {
        Console.Write("List of size {0} of type {1}: ", items.Count, typeof(T).Name);
        // Use kamdba expression
        items.ForEach(item => Console.Write($"{item} "));
        Console.WriteLine();
    }

    public IEnumerable<T> GetAll() {
        return items;
    }
}