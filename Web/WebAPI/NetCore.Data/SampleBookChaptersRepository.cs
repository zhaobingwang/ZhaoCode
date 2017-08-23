using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data
{
    public class SampleBookChaptersRepository:IBookChaptersRepository
    {
        private readonly ConcurrentDictionary<Guid, BookChapter> _chapters = new ConcurrentDictionary<Guid, BookChapter>();

        public void Add(BookChapter bookChapter)
        {
            bookChapter.Id = Guid.NewGuid();
            _chapters[bookChapter.Id] = bookChapter;
        }

        public BookChapter Find(Guid id)
        {
            BookChapter chapter;
            _chapters.TryGetValue(id, out chapter);
            return chapter;
        }

        public IEnumerable<BookChapter> GetAll()
        {
            return _chapters.Values;
        }
        public IEnumerable<BookChapter> GetAll2() => _chapters.Values;

        public void Init()
        {
            Add(new BookChapter
            {
                Number = 1,
                Title = "第一章:C#基础",
                Pages = 50
            });
            Add(new BookChapter
            {
                Number = 2,
                Title = "第二章：WebAPI",
                Pages = 30
            });
        }

        public BookChapter Remove(Guid id)
        {
            BookChapter removed;
            _chapters.TryRemove(id, out removed);
            return removed;
        }

        public void Update(BookChapter bookChapter)
        {
            _chapters[bookChapter.Id] = bookChapter;
        }
    }
}
