using Demokrata.DTOs;
using Demokrata.Services;
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
                if (usuario == null)
                {
                    return NotFound(new { code = 404, message = "Usuario no encontrado." });
                }

                return Ok(new { code = 200, message = "Usuario obtenido exitosamente.", data = usuario });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el usuario con ID {id}");
                return StatusCode(500, new
                {
                    code = 500,
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
                return Ok(new { code = 200, message = "Usuarios obtenidos exitosamente.", data = usuarios });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de usuarios");
                return StatusCode(500, new
                {
                    code = 500,
                    message = "Ocurrió un error al intentar obtener la lista de usuarios.",
                    details = ex.Message
                });
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string? primerNombre, string? primerApellido, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (pageNumber <= 0 || pageSize <= 0)
                {
                    return BadRequest(new { code = 400, message = "Los parámetros pageNumber y pageSize deben ser mayores a 0." });
                }

                var usuarios = await _usuarioService.SearchAsync(primerNombre, primerApellido, pageNumber, pageSize);

                return Ok(new
                {
                    code = 200,
                    message = "Usuarios obtenidos exitosamente.",
                    data = usuarios.Data,
                    totalRecords = usuarios.TotalRecords,
                    pageNumber,
                    pageSize
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al realizar la búsqueda de usuarios.");
                return StatusCode(500, new
                {
                    code = 500,
                    message = "Ocurrió un error al intentar buscar usuarios.",
                    details = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        message = "Datos inválidos.",
                        errors = ModelState
                    });
                }

                var usuario = await _usuarioService.CreateAsync(usuarioDto);
                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, new
                {
                    code = 201,
                    message = "Usuario creado exitosamente.",
                    data = usuario
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un usuario");
                return StatusCode(500, new
                {
                    code = 500,
                    message = "Ocurrió un error al intentar crear el usuario.",
                    details = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        message = "Datos inválidos.",
                        errors = ModelState
                    });
                }

                var result = await _usuarioService.UpdateAsync(id, usuarioDto);
                if (!result)
                {
                    return NotFound(new { code = 404, message = "Usuario no encontrado para actualizar." });
                }

                return Ok(new { code = 200, message = "Usuario actualizado exitosamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el usuario con ID {id}");
                return StatusCode(500, new
                {
                    code = 500,
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
                if (!result)
                {
                    return NotFound(new { code = 404, message = "Usuario no encontrado para eliminar." });
                }

                return Ok(new { code = 200, message = "Usuario eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el usuario con ID {id}");
                return StatusCode(500, new
                {
                    code = 500,
                    message = "Ocurrió un error al intentar eliminar el usuario.",
                    details = ex.Message
                });
            }
        }
    }
}
