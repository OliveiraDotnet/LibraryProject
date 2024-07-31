using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore
{
    public class RunTimeDataBaseFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var opcoes = new DbContextOptionsBuilder<LibraryContext>().UseLazyLoadingProxies()
                                                                      .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Teste;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
                                                                      b => b.MigrationsAssembly("LibraryNet.Repository")).Options;

            return new LibraryContext(opcoes);
        }
    }
}
    

