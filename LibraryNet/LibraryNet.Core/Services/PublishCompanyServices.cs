using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Utils.Extensions;

namespace LibraryNet.Core.Services
{
    public class PublishCompanyServices : IPublisherServices
    {
        protected IReadRepository<Repository.Models.Publisher> ReadRepositoryPublisher { get; }
        protected IWriteRepository<Repository.Models.Publisher> WriteRepositoryPublisher { get; }
        public PublishCompanyServices(IReadRepository<Repository.Models.Publisher> readRepositoryPublisher, IWriteRepository<Repository.Models.Publisher> writeRepositoryPublisher)
        {
            ReadRepositoryPublisher = readRepositoryPublisher;
            WriteRepositoryPublisher = writeRepositoryPublisher;
        }
        public async Task CreateAsync(Publisher publishCompany) => await WriteRepositoryPublisher.CreateAsync(publishCompany.Like<Repository.Models.Publisher>());
        public async Task DeleteAsync(string publishCompanyId) => await WriteRepositoryPublisher.DeleteAsync(new Repository.Models.Publisher { Id = publishCompanyId});
        public async Task<List<Publisher>> GetAllAsync() => (await ReadRepositoryPublisher.GetAllAsync()).Like<List<Publisher>>();
        public async Task UpdateAsync(Publisher publishCompany) => await WriteRepositoryPublisher.UpdateAsync(publishCompany.Like<Repository.Models.Publisher>());
    }
}
