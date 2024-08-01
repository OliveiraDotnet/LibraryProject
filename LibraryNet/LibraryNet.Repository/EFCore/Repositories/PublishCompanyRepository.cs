using LibraryNet.Repository.Models;

namespace LibraryNet.Repository.EFCore.Repositories
{
    public class PublishCompanyRepository : EFCoreRepository<PublishCompany>
    {
        public PublishCompanyRepository(LibraryContext context) : base(context)
        {
        }
    }
}
