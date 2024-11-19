using Demokrata.DTOs;
using Demokrata.Models;
using Demokrata.Repositories;

namespace Demokrata.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> GetByIdAsync(int id) => await _usuarioRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Usuario>> GetAllAsync() => await _usuarioRepository.GetAllAsync();
        public async Task<(IEnumerable<Usuario> Data, int TotalRecords)> SearchAsync(string? primerNombre, string? primerApellido, int pageNumber, int pageSize)
        {
            return await _usuarioRepository.SearchAsync(primerNombre, primerApellido, pageNumber, pageSize);
        }


        public async Task<Usuario> CreateAsync(UsuarioDTO usuarioDto)
        {
            // Validación personalizada para Fecha de Nacimiento
            if (usuarioDto.FechaNacimiento > DateTime.UtcNow)
            {
                throw new ArgumentException("La fecha de nacimiento no puede ser en el futuro.");
            }
         
            var usuario = new Usuario
            {
                PrimerNombre = usuarioDto.PrimerNombre,
                SegundoNombre = usuarioDto.SegundoNombre,
                PrimerApellido = usuarioDto.PrimerApellido,
                SegundoApellido = usuarioDto.SegundoApellido,
                FechaNacimiento = usuarioDto.FechaNacimiento,
                Sueldo = usuarioDto.Sueldo,
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            };

            return await _usuarioRepository.CreateAsync(usuario);
        }

        public async Task<bool> UpdateAsync(int id, UsuarioDTO usuarioDto)
        {
            // Busca el usuario existente en la base de datos
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null)
            {
                return false; // Usuario no encontrado
            }

            // Actualiza las propiedades del usuario existente con los valores del DTO
            usuarioExistente.PrimerNombre = usuarioDto.PrimerNombre;
            usuarioExistente.SegundoNombre = usuarioDto.SegundoNombre;
            usuarioExistente.PrimerApellido = usuarioDto.PrimerApellido;
            usuarioExistente.SegundoApellido = usuarioDto.SegundoApellido;
            usuarioExistente.FechaNacimiento = usuarioDto.FechaNacimiento;
            usuarioExistente.Sueldo = usuarioDto.Sueldo;
            usuarioExistente.FechaModificacion = DateTime.UtcNow;

            // Envía el usuario actualizado al repositorio
            return await _usuarioRepository.UpdateAsync(id, usuarioExistente);
        }


        public async Task<bool> DeleteAsync(int id) =>
            await _usuarioRepository.DeleteAsync(id);
    }
}
