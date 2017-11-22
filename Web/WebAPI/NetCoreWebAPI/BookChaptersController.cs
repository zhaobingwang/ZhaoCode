using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreWebAPI
{
    [Route("api/[controller]")]
    public class BookChaptersController : Controller
    {
        private readonly IBookChaptersRepository _repository;
        public BookChaptersController(IBookChaptersRepository bookChaptersRepository)
        {
            _repository = bookChaptersRepository;
        }
        // GET: api/bookchapters
        [HttpGet]
        public IEnumerable<BookChapter> GetBookChapters()
        {
            return _repository.GetAll();
        }

        // GET api/bookchapters/guid
        [HttpGet("{id}")]
        public IActionResult GetBookChapterById(Guid id)
        {
            BookChapter chapter = _repository.Find(id);
            if (chapter == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(chapter);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult PostBookChapter([FromBody]BookChapter chapter)
        {
            if (chapter==null)
            {
                return BadRequest();
            }
            _repository.Add(chapter);
            return CreatedAtRoute(nameof(GetBookChapterById), new { id = chapter.Id });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult PutBookChapter(Guid id, [FromBody]BookChapter chapter)
        {
            if (chapter==null||id!=chapter.Id)
            {
                return BadRequest();
            }
            if (_repository.Find(id)==null)
            {
                return NotFound();
            }
            _repository.Update(chapter);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
