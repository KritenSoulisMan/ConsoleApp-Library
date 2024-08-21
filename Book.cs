

namespace Library
{
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
