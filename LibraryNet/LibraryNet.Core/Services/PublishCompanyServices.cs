using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Utils.Extensions;

namespace LibraryNet.Core.Services
{
    public class PublishCompanyServices : IPublishCompanyServices
    {
        protected IReadRepository<Repository.Models.PublishCompany> ReadRepositoryPublishCompany { get; }
        protected IWriteRepository<Repository.Models.PublishCompany> WriteRepositoryPublishCompany { get; }
        public PublishCompanyServices(IReadRepository<Repository.Models.PublishCompany> readRepositoryPublishCompany, IWriteRepository<Repository.Models.PublishCompany> writeRepositoryPublishCompany)
        {
            ReadRepositoryPublishCompany = readRepositoryPublishCompany;
            WriteRepositoryPublishCompany = writeRepositoryPublishCompany;
        }
        public async Task CreateAsync(PublishCompany publishCompany) => await WriteRepositoryPublishCompany.CreateAsync(publishCompany.Like<Repository.Models.PublishCompany>());
        public async Task DeleteAsync(string publishCompanyId) => await WriteRepositoryPublishCompany.DeleteAsync(new Repository.Models.PublishCompany { Id = publishCompanyId});
        public async Task<List<PublishCompany>> GetAllAsync() => (await ReadRepositoryPublishCompany.GetAllAsync()).Like<List<PublishCompany>>();
        public async Task UpdateAsync(PublishCompany publishCompany) => await WriteRepositoryPublishCompany.UpdateAsync(publishCompany.Like<Repository.Models.PublishCompany>());
    }
}
