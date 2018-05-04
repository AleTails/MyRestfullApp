using System.Threading.Tasks;

namespace MyRestfullApp.Infrastructure.Data.SeedDatabase
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}