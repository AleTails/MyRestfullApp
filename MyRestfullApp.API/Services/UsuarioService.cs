using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRestfullApp.API.Services.Interfaces;
using MyRestfullApp.Infrastructure.Data;
using MyRestfullApp.Infrastructure.Data.Model;

namespace MyRestfullApp.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MyRestfullAppContext _context;

        public UsuarioService(MyRestfullAppContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            var newUsuario = await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return newUsuario.Entity;
        }

        public async Task<Usuario> GetUsuario(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> UpdateUsuario(Guid id, Usuario usuario)
        {
            var savedUsuario = await _context.Usuarios.FirstAsync(u => u.Id == id);

            savedUsuario.Apellido = usuario.Apellido;
            savedUsuario.Nombre = usuario.Nombre;
            savedUsuario.Email = usuario.Email;
            savedUsuario.Password = usuario.Password;

            await _context.SaveChangesAsync();
            return savedUsuario;
        }

        public async Task DeleteUsuario(Guid id)
        {
            _context.Usuarios.Remove(await _context.Usuarios.FirstAsync(u => u.Id == id));
            await _context.SaveChangesAsync();
        }

    }
}
