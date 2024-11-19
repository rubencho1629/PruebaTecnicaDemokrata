using Demokrata.Models;
using Demokrata.Repositories;
using Demokrata.Services;
using Moq;
using Xunit;

public class UsuarioServiceTests
{
    [Fact]
    public async Task CreateAsync_Should_Call_Repository_CreateAsync()
    {
        // Arrange
        var mockRepo = new Mock<UsuarioRepository>();
        var service = new UsuarioService(mockRepo.Object);

        var usuario = new Usuario
        {
            PrimerNombre = "Juan",
            PrimerApellido = "Pérez",
            FechaNacimiento = new DateTime(1990, 1, 1),
            Sueldo = 5000,
        };

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Usuario>())).ReturnsAsync(usuario);

        // Act
        var result = await service.CreateAsync(new Demokrata.DTOs.UsuarioDTO
        {
            PrimerNombre = "Juan",
            PrimerApellido = "Pérez",
            FechaNacimiento = new DateTime(1990, 1, 1),
            Sueldo = 5000,
        });

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Juan", result.PrimerNombre);
        mockRepo.Verify(r => r.CreateAsync(It.IsAny<Usuario>()), Times.Once);
    }
}