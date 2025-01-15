namespace Assignment4;

class Program {
    static void Main(string[] args) {
        // Custom Stack used MyList within it
        MyStack<int> stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(3);
        stack.Push(5);
        stack.PrintList();
        stack.Pop();
        stack.PrintList();

        // Generic Repository
        GenericRepository<Product> productRepository = new GenericRepository<Product>();
        Product product1 = new Product { Id = 1, Name = "Laptop", Price = 1200 };
        productRepository.Add(product1);
        productRepository.Add(new Product { Id = 2, Name = "Tablet", Price = 800 });
        productRepository.Save();

        Product foundProduct = productRepository.GetById(1);
        Console.WriteLine($"Found product by ID 1. Name: {foundProduct.Name}, Price: {foundProduct.Price}");
        var products = productRepository.GetAll();
        Console.WriteLine("All products: " + string.Join(", ", products.Select(p => p.Name)));
        Console.WriteLine("All products prices: $" + string.Join(", $", products.Select(p => p.Price)));
    }
}