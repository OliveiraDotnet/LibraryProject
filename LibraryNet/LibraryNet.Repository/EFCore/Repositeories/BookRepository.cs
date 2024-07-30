namespace LibraryNet.Repository.EFCore.Repositeories
{
    internal class BookRepository : EFCoreRepository<Book, LibraryContext>
    {
        public BookRepository(LibraryContext context) : base(context)
        {

        }
    }
}
