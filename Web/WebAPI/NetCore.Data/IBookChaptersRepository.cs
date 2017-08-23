using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data
{
    public interface IBookChaptersRepository
    {
        void Init();
        void Add(BookChapter bookChapter);
        IEnumerable<BookChapter> GetAll();
        BookChapter Find(Guid id);
        BookChapter Remove(Guid id);
        void Update(BookChapter bookChapter);
    }
}
