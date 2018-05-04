using MyRestfullApp.Infrastructure.Data.Model;

namespace MyRestfullApp.API.Dtos
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Usuario ToUsuario()
        {
           return new Usuario
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Email = Email,
                Password = Password
            };
        }
    }
}