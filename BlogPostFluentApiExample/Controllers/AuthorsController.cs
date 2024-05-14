using AutoMapper;
using BlogPostFluentApiExample.DAL;
using BlogPostFluentApiExample.DTOs;
using BlogPostFluentApiExample.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostFluentApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorDAL _authorDAL;
        private readonly IGenericRepository<Author> genericAuthorRepository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<Author> _authorValidator;
        public AuthorsController(IAuthorDAL authorDAL, IMapper mapper, IGenericRepository<Author> genericAuthorRepository)
        {
            _authorDAL = authorDAL;
            _mapper = mapper;
            _authorValidator = new AuthorValidator();
            this.genericAuthorRepository = genericAuthorRepository;
        }

        /// <summary>
        /// get all the authors
        /// </summary>
        /// <remarks>authors</remarks>
        /// <returns>get all the authorsss</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await genericAuthorRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthors(AuthorDto authorDto)
        {
            Author author = _mapper.Map<Author>(authorDto);

            var validationResult = _authorValidator.Validate(author);

            if (validationResult.IsValid)
            {
                Author resultAuthor = await _authorDAL.AddAuthorsRepository(author);
                return Ok("New Author has been added successfully");
            }

            return BadRequest(validationResult.Errors);

        }

    }
}
