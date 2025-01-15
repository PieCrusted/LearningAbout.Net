namespace Assignment4;

// Entity Example with ID
public class Entity {
    public int Id { get; set; }
}

// IRepository Interface
public interface IRepository<T> where T : Entity {
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

// Generic Repository class
public class GenericRepository<T> : IRepository<T> where T : Entity {
    private MyList<T> _data = new MyList<T>();

    public void Add(T item) {
        _data.Add(item);
    }

    public void Remove(T item) {
        _data.Delete(item);
    }

    public void Save() {
        // TODO: Save
        Console.WriteLine("Changes saved.");
    }

    public IEnumerable<T> GetAll() {
        return _data.GetAll();
    }

    public T GetById(int id) {
        return GetAll().FirstOrDefault(x => x.Id == id);
    }
}

// Example Entity to Test
public class Product : Entity {
    public string Name { get; set; }
    public decimal Price { get; set; }
}