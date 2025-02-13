using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Business
{
    internal class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // 获取所有图书
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        // 获取特定图书
        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        // 添加新书
        public string AddBook(string title, string author, string isbn, int stock, string publisher, DateTime publishDate)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || stock < 0)
            {
                return "书籍信息不完整或库存错误";
            }

            var book = new Book
            {
                Author = author,
                ISBN = isbn,
                Stock = stock,
                Publisher = publisher
            };

            _bookRepository.Add(book);
            return "图书添加成功";
        }

        // 更新图书
        public string UpdateBook(int id, string title, string author, string isbn, int stock, string publisher, DateTime publishDate)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return "书籍不存在";
            }

            book.Author = author;
            book.ISBN = isbn;
            book.Stock = stock;
            book.Publisher = publisher;

            _bookRepository.Update(book);
            return "图书信息更新成功";
        }

        // 删除图书
        public string DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return "书籍不存在";
            }

            _bookRepository.Delete(id);
            return "图书删除成功";
        }
    }
}
