using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;
using System.Text.RegularExpressions;

namespace Library
{
    class Program
    {
        static List<Book> Books = new List<Book>();
        static List<Reader> Readers = new List<Reader>();

        static void Main()
        {
            LoadData();
            while (true)
            {
                Console.WriteLine("Выберите пункт: \n" +
                    "1. Управление книгами.\n" +
                    "2. Управление пользователями.\n");

                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.Clear();
                        SwitchParamsBooks();
                        break;
                    case 2:
                        Console.Clear();
                        SwitchParamsReader();
                        break;
                    case 3:
                        Console.Clear();
                        SaveData();
                        return;
                }
            }
        }

        static void SaveData()
        {
            var jsonSaver = new ListToJsonSaver<Book>();
            jsonSaver.SaveListToJson(Books, "books.json");

            var readerSaver = new ListToJsonSaver<Reader>();
            readerSaver.SaveListToJson(Readers, "users.json");
        }

        static void LoadData()
        {

            var jsonSaver = new ListToJsonSaver<Book>();
            jsonSaver.SaveListToJson(Books, "books.json");

            var readerSaver = new ListToJsonSaver<Reader>();
            readerSaver.SaveListToJson(Readers, "users.json");
        }

        static void SwitchParamsBooks()
        {
            while (true)
            {
                Console.WriteLine("Выберите пункт: \n" +
                    "1. Добавить книгу.\n" +
                    "2. Список книг.\n" +
                    "3. Удалить книгу.");

                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.Clear();
                        AddBook();
                        break;
                    case 2:
                        Console.Clear();
                        ShowBook();
                        break;
                    case 3:
                        Console.Clear();
                        RemoveBook();
                        break;
                    case 4:
                        return;
                }
            }
        }

        static void SwitchParamsReader()
        {
            while (true)
            {
                Console.WriteLine("Выберите пункт: \n" +
                    "1. Добавить пользователя.\n" +
                    "2. Список пользователей.\n" +
                    "3. Удалить пользователя.");

                int b = int.Parse(Console.ReadLine());
                switch (b)
                {
                    case 1:
                        Console.Clear();
                        AddReader();
                        break;
                    case 2:
                        Console.Clear();
                        ShowReader();
                        break;
                    case 3:
                        Console.Clear();
                        RemoveReader();
                        break;
                    case 4:
                        return;
                }
            }
        }

        /// <summary>
        /// Блок для управления Книгами
        /// </summary>
        static void AddBook()
        {
            while (true)
            {
                int num;
                Console.WriteLine("Какое название у книги?");
                string title = Console.ReadLine();
                if (int.TryParse(title, out num))
                {
                    Console.WriteLine("В имени не бывает чисел!");
                    break;
                }
                else
                {
                    AddBook();
                }

                Console.WriteLine("Кто автор этой книги?");
                string author = Console.ReadLine();
                if (int.TryParse(author, out num))
                {
                    Console.WriteLine("В имени не бывает чисел!");
                    break;
                }
                else
                {
                    AddBook();
                }

                Console.WriteLine("О чем книга?");
                string description = Console.ReadLine();
                if (int.TryParse(description, out num))
                {
                    Console.WriteLine("В имени не бывает чисел!");
                    break;
                }
                else
                {
                    AddBook();
                }

                Console.WriteLine("Сколько страниц в книге?");
                int pages = int.Parse(Console.ReadLine());

                Console.WriteLine("Какой жанр у книги?");
                string genre = Console.ReadLine();
                if (int.TryParse(genre, out num))
                {
                    Console.WriteLine("В имени не бывает чисел!");
                    break;
                }
                else
                {
                    AddBook();
                }

                var book = new Book(title, author, description, pages, genre);

                Console.WriteLine("Книга успешно добавлена!");
                Books.Add(book);


            }
        }

        static void ShowBook()
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

        static void RemoveBook()
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
                                Console.Clear();
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

        /// <summary>
        /// Блок для управления пользователями
        /// </summary>


        static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        static void AddReader()
        {
            int ID = Books.Count + 1;
            int num;

            Console.WriteLine("Введите имя пользователя: ");
            string Name = Console.ReadLine();
            if (int.TryParse(Name, out num))
            {
                Console.WriteLine("В имени не бывает чисел!");
            }

            Console.WriteLine("Введите почту пользователя: ");
            string Email = Console.ReadLine();
            if (!IsValidEmail(Email))
            {
                Console.WriteLine("Некоректный формат email");
            }

            var reader = new Reader(ID, Name, Email);
            Console.WriteLine("Добавлен новый пользователь.");
            Readers.Add(reader);
        }

        static void ShowReader()
        {
            if (Readers.Count == 0)
            {
                Console.WriteLine("Здесь есть кто?");
                return;
            }
            
            Console.WriteLine("Список пользователей: ");
            for (int i = 0; i < Readers.Count; i++)
            {
                int num = i;
                Console.WriteLine($"ID: {num} \n" +
            $"Никнейм: {Readers[i].Name}. \n" +
            $"Почта: {Readers[i].Mail}. \n");
            }
        }

        static void RemoveReader()
        {
            if (Readers.Count != 0)
            {
                for (int i = 0; i < Readers.Count; i++)
                {
                    Console.WriteLine($"ID: {Readers[i].ID}");
                }

                Console.WriteLine("Сколько Пользователей желаете удалить?\n" +
                    "1. Несколько." +
                    "2. Всех.");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Напишите ID пользователя из списка: ");
                        int a = int.Parse(Console.ReadLine());
                        Readers.RemoveAt(a);
                        Console.WriteLine("Пользователь был удален");
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
                        Console.WriteLine("Все Пользователи были удалены!");
                        Readers.Clear(); // Очистить весь массив.
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("В данный момент нету новых регистраций... " +
                    "Приходите завтра.");
                Console.Clear();
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

    class Reader
    {
        public int ID;
        public string Name;
        public string Mail;

        public Reader(int ID, string Name, string Mail)
        {
            this.ID = ID;
            this.Name = Name;
            this.Mail = Mail;
        }
    }

    public class ListToJsonSaver<T>
    {
        public void SaveListToJson(List<T> list, string filePath)
        {
            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<T> LoadListFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
