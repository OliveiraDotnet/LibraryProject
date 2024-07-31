using AutoMapper;
using LibraryNet.Core.Models.VO;

namespace LibraryNet.Core.Configuration
{
    public class MappingProfileCore : Profile
    {
        public MappingProfileCore()
        {
            CreateMap<Repository.Models.Book, Models.Book>();
            CreateMap<Repository.Models.Author, Models.Author>();
            CreateMap<Repository.Models.PublishCompany, Models.PublishCompany>();

            CreateMap<Models.Book, BookVO>().ForMember(vo => vo.Author, map => map.MapFrom(d => d.Author.Name))
                                            .ForMember(vo => vo.PublishCompany, map => map.MapFrom(d => d.PublishCompany.Name));

            CreateMap<Models.Author, AuthorVO>();
            CreateMap<Models.PublishCompany, PublishCompanyVO>();
        }
    }
}
