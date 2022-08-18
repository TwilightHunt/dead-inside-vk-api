using GenericsExmpl;

namespace GenericExmpl;
class Program
{
    public static void Main(string[] args)
    {
        Storage storage = new Storage();
        storage.Set("Cat", new Cat { Name = "The best cat ever"});

        Cat? cat = storage.Get<Cat>("Cat");
        Console.WriteLine(cat?.Name?? "Scary name");
    }
    class Cat
    {
        public string Name { get; set; }

    }
}
