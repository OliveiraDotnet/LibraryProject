using AutoMapper;
using FluentValidation.Results;

namespace LibraryNet.Utils.Validators
{
    public class MapProfileValidator : Profile
    {
        public MapProfileValidator()
        {
            CreateMap<ValidationResult, ValidationResult>();
            CreateMap<ValidationFailure, ErrorValidation>().ForMember(d => d.Message, op => op.MapFrom(o => o.ErrorMessage));
        }
    }
}