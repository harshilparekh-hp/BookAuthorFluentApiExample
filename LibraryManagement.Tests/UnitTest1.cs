using AutoMapper;
using BlogPostFluentApiExample;
using BlogPostFluentApiExample.Controllers;
using BlogPostFluentApiExample.DAL;
using BlogPostFluentApiExample.DTOs;
using BlogPostFluentApiExample.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryManagement.Tests
{
    [TestClass]
    public class LibraryManagementApiTests
    {
        private readonly Mock<IAuthorDAL> _authorMockDAL = new Mock<IAuthorDAL>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        //[TestMethod]
        //public async Task GetAuthorsTest_Returns_Authors()
        //{
        //    // AAA

        //    // Arrange
            
        //    // we need the objects - AuthorsController - DONE, AuthorDAL - DONE, Author - DONE

        //    var authors = new List<Author>
        //    {
        //        new Author {AuthorId = 1, AuthorName = "Harshil", AuthorEmail = "hp@mail.com", Publication = "Parekh Publications" },
        //        new Author {AuthorId = 2, AuthorName = "Stefano", AuthorEmail = "s@mail.com", Publication = "Stefano Publications" },
        //    };

        //    // _authorMockDAL will have list of authors which is being returned from GetAuthorsRepository().
        //    // Here, we have used Mock to fool GetAuthorsRepository() method to return the list of authors.
        //    _authorMockDAL.Setup(x => x.GetAuthorsRepository()).Returns(Task.FromResult(authors.ToList()));
            
        //    var authorController = new AuthorsController(_authorMockDAL.Object, _mapperMock.Object);

        //    // Act

        //    var actualResult = await authorController.GetAuthors();

        //    // Assert
        //    Assert.IsNotNull(actualResult);

        //    var result = actualResult as OkObjectResult;

        //    var authorsFromResult = result.Value as List<Author>;
        //    Assert.AreEqual(authors.Count(), authorsFromResult.Count());
            

        //}

        //[TestMethod]
        //public async Task AddAuthorsTest_ReturnsAddedAuthor()
        //{
        //    // AAA

        //    // Arrange
        //    var authorDTO = new AuthorDto { AuthorId = 1, AuthorName = "Marcelo", AuthorEmail = "m@mail.com", Publication = "Marcelo Publications" };
        //    var mapperConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new MyMappingProfile());
        //    });

        //    IMapper mapper = mapperConfig.CreateMapper();

        //    _mapperMock.Setup(x => x.Map<Author>(authorDTO)).Returns(new Author());

        //    var authorController = new AuthorsController(_authorMockDAL.Object, mapper);

        //    // Act

        //    var actualResult = await authorController.AddAuthors(authorDTO);

        //    // Assert
        //    var result = actualResult as OkObjectResult;

        //    Assert.AreEqual("New Author has been added successfullyyyyy", result.Value);

        //}

    }
}