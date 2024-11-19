using Demokrata.Data;
using Demokrata.Models;
using Microsoft.EntityFrameworkCore;

namespace Demokrata.Repositories
{
    public class UsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateAsync(int id, Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                return false; // Usuario no encontrado
            }

            // Actualiza las propiedades del usuario existente
            usuarioExistente.PrimerNombre = usuario.PrimerNombre;
            usuarioExistente.SegundoNombre = usuario.SegundoNombre;
            usuarioExistente.PrimerApellido = usuario.PrimerApellido;
            usuarioExistente.SegundoApellido = usuario.SegundoApellido;
            usuarioExistente.FechaNacimiento = usuario.FechaNacimiento;
            usuarioExistente.Sueldo = usuario.Sueldo;
            usuarioExistente.FechaModificacion = usuario.FechaModificacion;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}