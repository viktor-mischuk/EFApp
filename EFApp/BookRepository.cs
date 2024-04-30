

using static System.Reflection.Metadata.BlobBuilder;

namespace EFApp
{
    internal class BookRepository
    {
        public void AddBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }
        
        //Удаление книги
        public void DeleteBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        //Выбор всех книг
        public List<Book> SelectAllBooks()
        {
            List<Book> allBooks = new List<Book>();    
            using (var db = new AppContext())
            {
                allBooks = db.Books.ToList();
                
            }
            return allBooks;
        }
        // Обновление книги
        public void UpdateBook(int id, int year)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
                book.YearOFIssue = year;
                db.SaveChanges();
            }
        }
        // Количество книг по автору
        public int GetAuthorBooks(string author)
        {
            int bookQ;
            using (var db = new AppContext())
            {
                bookQ = db.Books.Where(b => b.Author == author).Count();

            }
            return bookQ;
        }
        //Количество книг по жанру
        public int GetGenreQuantities(string genre)
        {
            int genreQ;
            using (var db = new AppContext())
            {
                genreQ = db.Books.Where(b => b.Genre == genre).Count();

            }
            return genreQ;
        }


       // Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool SelectUserBy(string author, string title)
        {
            bool isHas = false;
            using (var db = new AppContext())
            {
                var book = db.Books.Where(b => b.Author == author || b.Title == title).FirstOrDefault();
                if(book != null) isHas = true;

            }
            return isHas;
        }



        //Получение последней вышедшей книги.
        public Book GetLastIssued()
        {
            Book lastIssueYearBook;
            using (var db = new AppContext())
            {
                lastIssueYearBook = db.Books.MaxBy(b => b.YearOFIssue);
                
            }
            return lastIssueYearBook;
        }
        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> SortedBooksByTitle()
        {
            List<Book> books = new List<Book>();
            using (var db = new AppContext())
            {
                books = db.Books.OrderBy(b => b.Title).ToList();

            }
            return books;
        }
        //Получение списка всех книг, отсортированного в порядке убывания года их выхода
        public List<Book> SortedBooksByIssue()
        {
            List<Book> books = new List<Book>();
            using (var db = new AppContext())
            {
                books = db.Books.OrderByDescending(b => b.YearOFIssue).ToList();

            }
            return books;
        }

        // Выдача книги пользователю 
        public void GiveBook(int bookId, int userId)
        {
            using (var db = new AppContext())
            {
                var book =db.Books.Where(b => b.Id == bookId).FirstOrDefault();
                book.HandOut = userId;
                db.SaveChanges();

            }
        }
    }
}
