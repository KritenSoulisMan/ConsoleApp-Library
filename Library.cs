

namespace Library
{
    class Library
    {

        List<Book> Books = new List<Book>();
        public Library()
        {
            // Пока-что не пригодился...
        }

        public void AddBook()
        {
            Console.WriteLine("Какое название у книги?");
            string title = Console.ReadLine();

            Console.WriteLine("Кто автор этой книги?");
            string author = Console.ReadLine();

            Console.WriteLine("О чем книга?");
            string description = Console.ReadLine();

            Console.WriteLine("Сколько страниц в книге?");
            int pages = int.Parse(Console.ReadLine());

            Console.WriteLine("Какой жанр у книги?");
            string genre = Console.ReadLine();

            var book = new Book(title, author, description, pages, genre);

            Books.Add(book);
        }

        public void RemnoveBook()
        {
            Console.WriteLine("В разработке...");
        }

        public void ShowBook()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("Кажись ещё не написали книг...");
                return;
            }
            // Выбор 1 эл. из всего списка и замена имени книги
            // Books[Books.Count - 1].Title = title;

            // Массив начинает счёт с 0!
            // Console.WriteLine(Books[0].Title); 

            Console.WriteLine("Список книг: ");
            // Цикл для вывода списка
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine("Название книги: " + Books[i].Title + ". " +
            ". Автор книги: " + Books[i].Author + ". " +
            ". Описание книги: " + Books[i].Description + ". " +
            ". Кол-во страниц в книге: " + Books[i].Pages + "стр. " +
            "Жанр книги: " + Books[i].Genre + ". ");
            }
                
        }
    }
}
