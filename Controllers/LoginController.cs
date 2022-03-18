using AutoMapper;
using blissBackend.Dto.AuthDto;
using blissBackend.Models.Login;
using blissBackend.repository.ClientService;
using Microsoft.AspNetCore.Mvc;

namespace blissBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;
        private readonly IMapper _mapper;
        public BooksController(BooksService booksService, IMapper mapper)
        {
            _booksService = booksService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<theLoginDto>> myGet()
        {

            List<Book> myData = await _booksService.GetAsync();

            var result = _mapper.Map<List<theLoginDto>>(myData);
            if (result is null){
                return new List<theLoginDto>();
            }
            
            return result;

        }

        [HttpGet("{id:length(24)}", Name = "GetPostById")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]myLoginDto newBook)
        {
            var result = _mapper.Map<Book>(newBook);

            await _booksService.Create(result);
            // return CreatedAtAction(nameof(Get), new { id = result.Id }, newBook);
            var myData = _mapper.Map<readUserInfo>(result);
            return CreatedAtRoute("GetPostById", new {Id = myData.Id},myData);

        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Book updatedBook)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            updatedBook.Id = book.Id;
            await _booksService.UpdateAsync(id, updatedBook);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            await _booksService.RemoveAsync(id);
            return NoContent();
        }
    }
}