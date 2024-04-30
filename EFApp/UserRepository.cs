using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EFApp
{
    public class UserRepository
    {
        // добавить пользователя
        public void AddUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        // удалить пользователя
        public void DeleteUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        // выбрать всех пользователей
        public List<User> SelectAllUsers()
        {
            using (var db = new AppContext())
            {
                var allUsers = db.Users.ToList();
                return allUsers;
            }
        }
        // выбрать пользователя по id
        public User SelectUserById(int id)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                return user;
            }
        }
        // обновить пользователя
        public void UpdateUser(int id, string name)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                user.Name = name;
                db.SaveChanges();
            }
        }
        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool SelectUserById(int userId, int bookId)
        {
            bool isHas;
            using (var db = new AppContext())
            {
                var books = db.Users.Where(u => u.Id == userId).FirstOrDefault().TakenBooks;

                isHas = books.Contains(bookId);

            }
            return isHas;
        }
        //Получать количество книг на руках у пользователя.
        public int GetTakenBooks(int userId)
        {
            int booksQ;
            using (var db = new AppContext())
            {
                booksQ = db.Users.Where(u => u.Id == userId).FirstOrDefault().TakenBooks.Count();
            }
            return booksQ;
        }
        //взять книгу
        public void GetBook(int userId, int bookId)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
                user.TakenBooks.Add(bookId);
                db.SaveChanges();
            }
        }
    }
}
