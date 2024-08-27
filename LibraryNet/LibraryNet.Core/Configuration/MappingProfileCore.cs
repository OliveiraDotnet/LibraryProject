using AutoMapper;
using LibraryNet.Core.Enums;
using LibraryNet.Core.Models.VO;
using LibraryNet.Utils.Extensions;

namespace LibraryNet.Core.Configuration
{
    public class MappingProfileCore : Profile
    {
        public MappingProfileCore()
        {
            CreateMap<AuthorVO, Models.Author>().ReverseMap();
            CreateMap<PublisherVO, Models.Publisher>().ReverseMap();
            CreateMap<Models.Author, Repository.Models.Author>().ReverseMap();
            CreateMap<Models.Publisher, Repository.Models.Publisher>().ReverseMap();

            CreateMap<Models.Book, BookVO>().ForMember(vo => vo.AuthorId, map => map.MapFrom(vo => vo.Author.Id))
                                            .ForMember(vo => vo.PublisherId, map => map.MapFrom(vo => vo.Publisher.Id))
                                            .ReverseMap()
                                            .ForPath(d => d.Author.Id, map => map.MapFrom(vo => vo.AuthorId))
                                            .ForPath(d => d.Publisher.Id, map => map.MapFrom(vo => vo.PublisherId));
            CreateMap<Models.Book, Repository.Models.Book>().ForMember(p => p.Translation, map => map.MapFrom(d => d.Translation.EnumValue()))
                                                            .ForMember(p => p.Category, map => map.MapFrom(d => string.Join(";", (short)d.Category.EnumValue())))
                                                            .ForMember(p => p.AuthorId, map => map.MapFrom(d => d.Author.Id))
                                                            .ForMember(p => p.PublisherId, map => map.MapFrom(d => d.Publisher.Id))
                                                            .ForMember(p => p.Author, map => map.Ignore())
                                                            .ForMember(p => p.Publisher, map => map.Ignore())
                                                            .ReverseMap()
                                                            .ForMember(d => d.Translation, map => map.MapFrom(p => (Language)p.Translation))
                                                            .ForMember(d => d.Category, map => map.MapFrom(p => (LiteraryGenre)p.Category));
        }
    }
}
