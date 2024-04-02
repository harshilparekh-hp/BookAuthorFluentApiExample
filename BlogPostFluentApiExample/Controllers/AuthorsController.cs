﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly AbstractValidator<Author> _authorValidator;
        public AuthorsController(IAuthorDAL authorDAL, IMapper mapper)
        {
            _authorDAL = authorDAL;
            _mapper = mapper;
            _authorValidator = new AuthorValidator();
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await _authorDAL.GetAuthorsRepository());
        }


        [HttpPost]
        public async Task<IActionResult> AddAuthors(AuthorDto authorDto)
        {
            Author author = _mapper.Map<Author>(authorDto);

            var validationResult = _authorValidator.Validate(author);

            if (validationResult.IsValid)
            {
                _authorDAL.AddAuthorsRepository(author);
                return Ok("New Author has been added successfully");
            }

            return BadRequest(validationResult.Errors);

        }

        // Add new author to the database with below conditions
        // 1. Fluent Validation to validate my model
        // 2. Use DTO


    }
}