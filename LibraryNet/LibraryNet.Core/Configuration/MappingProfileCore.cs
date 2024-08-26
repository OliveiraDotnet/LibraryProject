﻿using AutoMapper;
using LibraryNet.Core.Models.VO;

namespace LibraryNet.Core.Configuration
{
    public class MappingProfileCore : Profile
    {
        public MappingProfileCore()
        {
            CreateMap<Models.Book, Repository.Models.Book>().ReverseMap();
            CreateMap<Models.Book, Repository.Models.Book>().ReverseMap();
            CreateMap<Models.Author, Repository.Models.Author>().ReverseMap();
            CreateMap<Models.Publisher, Repository.Models.Publisher>().ReverseMap();

            CreateMap<Models.Book, BookVO>().ForMember(vo => vo.Author, map => map.MapFrom(d => d.Author.Name))
                                            .ForMember(vo => vo.Publisher, map => map.MapFrom(d => d.Publisher.Name));

            CreateMap<AuthorVO, Models.Author>();
            CreateMap<Publisher, Models.Publisher>();
        }
    }
}
