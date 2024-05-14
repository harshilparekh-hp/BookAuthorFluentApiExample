using AutoMapper;
using BlogPostFluentApiExample.DAL;
using BlogPostFluentApiExample.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostFluentApiExample.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        // private readonly IBookDAL _bookDAL;
        private readonly IGenericRepository<Book> genericBookRepository;

        public BooksController(IMapper mapper, IGenericRepository<Book> genericBookRepository )
        {
            _mapper = mapper;
            this.genericBookRepository = genericBookRepository;
        }

        /// <summary>
        /// Get Book Api Endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await genericBookRepository.GetAll());
        }


    }
}
