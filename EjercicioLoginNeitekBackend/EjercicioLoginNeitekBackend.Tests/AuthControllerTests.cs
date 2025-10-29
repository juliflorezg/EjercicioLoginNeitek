using EjercicioLoginNeitekBackend.Controllers;
using EjercicioLoginNeitekBackend.DTOs;
using EjercicioLoginNeitekBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EjercicioLoginNeitekBackend.Tests;

public class AuthControllerTests
{
    [Fact]
    public async Task Login_WithValidCredentials_ReturnsOkWithToken()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var mockJwtService = new Mock<IJwtService>();

        var fakeUser = new UserDTO
        {
            Id = Guid.NewGuid(),
            Email = "test@example.com",
            UserTypeId = 1
        };

        mockUserService
            .Setup(s => s.GetByEmail(It.Is<LoginDTO>(l => l.Email == "test@example.com")))
            .Returns(fakeUser);

        mockUserService
            .Setup(s => s.ValidatePassword(It.IsAny<LoginDTO>()))
            .Returns(true);

        mockUserService
            .Setup(s => s.GetUserTypeNameById(It.IsAny<UserDTO>()))
            .ReturnsAsync("Admin");

        mockJwtService
            .Setup(j => j.GenerateToken(fakeUser.Id, fakeUser.Email, "Admin"))
            .Returns("fake.jwt.token");

        var controller = new AuthController(mockUserService.Object, mockJwtService.Object);

        var loginDto = new LoginDTO
        {
            Email = "test@example.com",
            Password = "1234"
        };

        // Act
        var result = await controller.Login(loginDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<Dictionary<string, object>>(okResult.Value! as IDictionary<string, object> ?? new Dictionary<string, object>());
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Login_NonExistingUser_ReturnsUnauthorized()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var mockJwtService = new Mock<IJwtService>();


        mockUserService
            .Setup(s => s.GetByEmail(It.Is<LoginDTO>(l => l.Email == "wrong@example.com")))
            .Returns((UserDTO?)null);

        var controller = new AuthController(mockUserService.Object, mockJwtService.Object);

        var loginDto = new LoginDTO
        {
            Email = "wrong@example.com",
            Password = "badpass"
        };

        // Act
        var result = await controller.Login(loginDto);

        // Assert
        var badRequest = Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal("Credenciales invalidas", badRequest.Value);
    }

    [Fact]
    public async Task Login_InvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var mockUserService = new Mock<IUserService>();
        var mockJwtService = new Mock<IJwtService>();

        var fakeUser = new UserDTO
        {
            Id = Guid.NewGuid(),
            Email = "test@example.com",
            UserTypeId = 1
        };

        mockUserService
            .Setup(s => s.GetByEmail(It.Is<LoginDTO>(l => l.Email == "test@example.com")))
            .Returns(fakeUser);

        mockUserService
            .Setup(s => s.ValidatePassword(It.IsAny<LoginDTO>()))
            .Returns(true);


        var controller = new AuthController(mockUserService.Object, mockJwtService.Object);

        var loginDto = new LoginDTO
        {
            Email = "wrong@example.com",
            Password = "badpass"
        };

        // Act
        var result = await controller.Login(loginDto);

        // Assert
        var badRequest = Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal("Credenciales invalidas", badRequest.Value);
    }
}
