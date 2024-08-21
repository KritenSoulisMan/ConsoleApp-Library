

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library(); // Для создания класса
            while (true)
            {
                Console.WriteLine("Выберите пункт: ");
                int arc = int.Parse(Console.ReadLine());

                switch (arc)
                {
                    case 0:
                        library.AddBook();
                        break;
                    case 1:
                        library.ShowBook();
                        break;
                }
            }
        }
    }
}
