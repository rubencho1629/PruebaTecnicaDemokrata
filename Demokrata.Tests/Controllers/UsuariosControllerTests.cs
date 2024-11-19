using Demokrata.Controllers;
using Demokrata.Data;
using Demokrata.DTOs;
using Demokrata.Models;
using Demokrata.Repositories;
using Demokrata.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;





public class UsuariosControllerTests
    {
        [Fact]
        public async Task Create_Should_Return_CreatedAtAction()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            var repository = new UsuarioRepository(context);
            var service = new UsuarioService(repository);
            var controller = new UsuariosController(service, null);

            var usuarioDto = new UsuarioDTO
            {
                PrimerNombre = "Juan",
                PrimerApellido = "Pérez",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Sueldo = 5000
            };

            // Act
            var result = await controller.Create(usuarioDto) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.IsType<Usuario>(result.Value);
        }
    }
