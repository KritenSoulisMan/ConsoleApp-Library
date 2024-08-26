

namespace Library
{
    class Program
    {
        List<Book> Books = new List<Book>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите пункт: \n" +
                    "1. Добавить книгу.\n" +
                    "2. Список книг.\n" +
                    "3. Удалить книгу.");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        ShowBook();
                        break;
                    case 3:
                        RemoveBook();
                        break;
                }
            }
        }

        void AddBook()
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

            Console.WriteLine("Книга успешно добавлена!");
            Books.Add(book);
        }

        void RemoveBook()
        {
            if (Books.Count != 0)
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Books[i].Title}");
                }

                Console.WriteLine("Сколько книг желаете удалить?\n" +
                    "1. Несколько." +
                    "2. Все.");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Напишите номер книги из списка: ");
                        int a = int.Parse(Console.ReadLine());
                        Books.RemoveAt(a);
                        Console.WriteLine("Книга была удалена");
                        Console.WriteLine("Хотите продолжить? (Да/Нет)");
                        switch (Console.ReadLine())
                        {
                            case "Да" or "да":
                                RemoveBook();
                                break;

                            case "Нет" or "нет":
                                Main();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Все книги были удалены!");
                        Books.Clear(); // Очистить весь массив.
                        break;
                }
            }
            else
            {
                Console.WriteLine("В данный момент книжный червь спит... " +
                    "Приходите завтра.");
            }
        }

        void ShowBook()
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
                int num = i;
                Console.WriteLine($"Книга под номером: {num} \n" +
            $"Название книги: {Books[i].Title}. \n" +
            $"Автор книги: {Books[i].Author}. \n" +
            $"Описание книги: {Books[i].Description}. \n" +
            $"Кол-во страниц в книге: {Books[i].Pages}стр. \n" +
            $"Жанр книги: {Books[i].Genre}. \n");
            }

        }
    }

    class Book
    {
        public string Title;
        public string Author;
        public string Description;
        public int Pages;
        public string Genre;


        public Book(string Title, string Author, string Description, int Pages, string Genre)
        {
            this.Title = Title;
            this.Author = Author;
            this.Description = Description;
            this.Pages = Pages;
            this.Genre = Genre;
        }
    }
}
