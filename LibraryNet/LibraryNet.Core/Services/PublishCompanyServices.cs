using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Utils.Extensions;

namespace LibraryNet.Core.Services
{
    public class PublishCompanyServices : IPublishCompanyServices
    {
        protected IReadRepository<PublishCompany> ReadRepositoryPublishCompany { get; }
        protected IWriteRepository<PublishCompany> WriteRepositoryPublishCompany { get; }
        public PublishCompanyServices(IReadRepository<PublishCompany> readRepositoryPublishCompany, IWriteRepository<PublishCompany> writeRepositoryPublishCompany)
        {
            ReadRepositoryPublishCompany = readRepositoryPublishCompany;
            WriteRepositoryPublishCompany = writeRepositoryPublishCompany;
        }
        public async Task CreateAsync(PublishCompany publishCompany) => await WriteRepositoryPublishCompany.CreateAsync(publishCompany.Like<PublishCompany>());

        public async Task DeleteAsync(string publishCompanyId) => await WriteRepositoryPublishCompany.DeleteAsync(new PublishCompany { Id = publishCompanyId});

        public async Task<List<PublishCompany>> GetAllAsync() => (await ReadRepositoryPublishCompany.GetAllAsync()).Like<List<PublishCompany>>();

        public async Task UpdateAsync(PublishCompany publishCompany) => await WriteRepositoryPublishCompany.UpdateAsync(publishCompany.Like<PublishCompany>());
    }
}
