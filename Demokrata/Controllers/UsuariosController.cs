using Demokrata.DTOs;
using Demokrata.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demokrata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(UsuarioService usuarioService, ILogger<UsuariosController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(id);
                if (usuario == null) return NotFound(new { message = "Usuario no encontrado." });

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el usuario con ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrió un error al intentar obtener el usuario.",
                    details = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de usuarios");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrió un error al intentar obtener la lista de usuarios.",
                    details = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioDTO usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Datos inválidos.", errors = ModelState });
                }

                var usuario = await _usuarioService.CreateAsync(usuarioDto);
                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrió un error al intentar crear el usuario.",
                    details = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioDTO usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "Datos inválidos.", errors = ModelState });
                }

                var result = await _usuarioService.UpdateAsync(id, usuarioDto);
                if (!result) return NotFound(new { message = "Usuario no encontrado." });

                return NoContent(); // Código 204 sin contenido
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el usuario con ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrió un error al intentar actualizar el usuario.",
                    details = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _usuarioService.DeleteAsync(id);
                if (!result) return NotFound(new { message = "Usuario no encontrado." });

                return NoContent(); // Código 204 sin contenido
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el usuario con ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrió un error al intentar eliminar el usuario.",
                    details = ex.Message
                });
            }
        }
    }
}
