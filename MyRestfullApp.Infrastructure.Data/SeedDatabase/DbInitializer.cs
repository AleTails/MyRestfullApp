using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRestfullApp.Infrastructure.Data.Model;

namespace MyRestfullApp.Infrastructure.Data.SeedDatabase
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MyRestfullAppContext _myResfullAppContext;

        public DbInitializer(MyRestfullAppContext myResfullAppContext)
        {
            _myResfullAppContext = myResfullAppContext;
        }

        public async Task Initialize()
        {
            _myResfullAppContext.Database.EnsureCreated();

            if (!_myResfullAppContext.Usuarios.Any())
            {
                _myResfullAppContext.Usuarios.AddRange(new List<Usuario>
                {
                    new Usuario
                    {
                        Apellido = "Perz",
                        Nombre = "Juan",
                        Email = "Juan@perez.com",
                        Password = "TestPassword"
                    },
                    new Usuario
                    {
                        Apellido = "Menganito",
                        Nombre = "Miguel",
                        Email = "Miguel@Menganito.com",
                        Password = "TestPassword"
                    },
                    new Usuario
                    {
                        Apellido = "Fernando",
                        Nombre = "Fulanito",
                        Email = "Fernando@Fulanito.com",
                        Password = "TestPassword"
                    }
                });
                await _myResfullAppContext.SaveChangesAsync();
            }
        }
    }
}
