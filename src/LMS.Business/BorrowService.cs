using LMS.Data;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Business
{
    internal class BorrowService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowRepository _borrowRepository;

        public BorrowService(IBorrowRepository borrowRepository,
            IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// 借书
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string BorrowBook(Guid bookId, Guid userId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book == null)
            {
                return "书籍不存在或库存不足";
            }

            var borrowRecord = new BorrowRecord
            {
                BookId = bookId,
                ReaderId = userId,
                BorrowDate = DateTime.Now
            };

            _borrowRepository.Add(borrowRecord);

            // 更新库存
            book.Stock -= 1;
            _bookRepository.Update(book);

            return "借阅成功";
        }

        public string ReturnBook(Guid recordId)
        {
            var record = _borrowRepository.GetById(recordId);
            if (record == null)
            {
                return "借阅记录不存在";
            }

            if (record.ReturnDate != null)
            {
                return "书籍已归还";
            }

            _borrowRepository.ReturnBook(recordId);

            // 归还后增加库存
            var book = _bookRepository.GetById(record.BookId);
            if (book != null)
            {
                book.Stock += 1;
                _bookRepository.Update(book);
            }

            return "归还成功";
        }

        // 获取所有借阅记录
        public List<BorrowRecord> GetAllBorrowRecords()
        {
            return _borrowRepository.GetAll();
        }
    }
}
