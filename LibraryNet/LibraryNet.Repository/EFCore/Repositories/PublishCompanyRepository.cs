using LibraryNet.Repository.Models;

namespace LibraryNet.Repository.EFCore.Repositories
{
    public class PublishCompanyRepository : EFCoreRepository<Publisher>
    {
        public PublishCompanyRepository(LibraryContext context) : base(context)
        {
        }
    }
}
