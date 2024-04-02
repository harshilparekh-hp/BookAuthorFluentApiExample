using AutoMapper;
using BlogPostFluentApiExample.Entities;

namespace BlogPostFluentApiExample.DTOs
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorDto>();
        }
    }
}
