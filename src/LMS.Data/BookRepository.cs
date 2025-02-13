using LMS.Models;
using LMS.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data
{
    internal class BookRepository : IBookRepository
    {
        private readonly BookDbContext _dbContext;

        public BookRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetById(long id)
        {
            return _dbContext.Books.SingleOrDefault(x => x.Id == id);
        }

        public List<Book> GetByName(string name)
        {
            return _dbContext.Books
                .Where(x => x.Name.Contains(name))
                .ToList(); ;
        }

        public void Add(Book book)
        {
            if (IsExist(book.Id))
            {
                throw new Exception("图书已存在，请勿重复添加");
            }
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            if (!IsExist(id))
            {
                throw new Exception("图书不存在，无法删除");
            }
            var book = GetById(id);
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public void Update(Book book)
        {
            if (!IsExist(book.Id))
            {
                throw new Exception("图书不存在，无法修改");
            }
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }


        private bool IsExist(long id)
        {
            return _dbContext.Books.Any(x => x.Id == id);
        }
    }
}
