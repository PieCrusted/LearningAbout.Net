namespace Assignment4;

public class MyStack<T> {
    private MyList<T> items;

    public MyStack() {
        items = new MyList<T>();
    }
    
    public int Count() {
        return items.Count();
    }
    
    public T Pop() {
        if (items.Count() == 0) {
            throw new InvalidOperationException("Stack is empty");
        }

        T item = items.Find(items.Count() - 1);
        items.DeleteAt(items.Count() - 1);
        return item;
    }

    public void Push(T item) {
        items.Add(item);
    }

    public void PrintList() {
        items.PrintList();
    }
}