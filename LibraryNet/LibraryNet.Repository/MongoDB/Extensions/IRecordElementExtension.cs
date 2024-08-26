using LibraryNet.Repository.Interfaces;
using MongoDB.Driver;

namespace LibraryNet.Repository.MongoDB.Extensions
{
    public static class IRecordElementExtension
    {
        public static FilterDefinition<T> GetIdFilter<T>(this T entidade) where T : IRecordElement
        {
            return Builders<T>.Filter.Where(o => o.Id == entidade.Id);
        }
    }
}
