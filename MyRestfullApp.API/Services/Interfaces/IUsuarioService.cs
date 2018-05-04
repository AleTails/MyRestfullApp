using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyRestfullApp.Infrastructure.Data.Model;

namespace MyRestfullApp.API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task DeleteUsuario(Guid id);
        Task<Usuario> GetUsuario(Guid id);
        Task<List<Usuario>> GetUsuarios();
        Task<Usuario> UpdateUsuario(Guid id, Usuario usuario);
    }
}