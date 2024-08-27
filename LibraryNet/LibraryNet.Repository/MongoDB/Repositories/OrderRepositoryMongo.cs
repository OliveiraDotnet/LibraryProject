using LibraryNet.Repository.Models;
using MongoDB.Driver;

namespace LibraryNet.Repository.MongoDB.Repositories
{
    public class OrderRepositoryMongo : MongoBaseRepository<Order>
    {
        protected override string BaseName => "TesteLibrary";
        protected override string CollectionName => "Orders";

        public OrderRepositoryMongo(IMongoClient mongoCliente) : base(mongoCliente)
        {
        }
    }
}
