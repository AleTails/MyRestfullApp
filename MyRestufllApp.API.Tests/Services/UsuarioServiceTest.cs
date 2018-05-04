using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRestfullApp.API.Dtos;
using MyRestfullApp.API.Services;
using MyRestfullApp.Infrastructure.Data;
using MyRestfullApp.Infrastructure.Data.Model;
using Xunit;

namespace MyRestufllApp.API.Tests.Services
{
    public class UsuarioServiceTest
    {
        [Fact]
        public async Task CreateUsuario_ShouldREturn_RecentlyCreatedUser()
        {
            // Arrange
            var newUsuarioMock = new Usuario
            {
                Apellido = "TestUserApellido",
                Nombre = "TestUserName",
                Email = "Test@UserEmail.com",
                Password = "TestPassword"
            };

            using (var fakeContext = await GenerateAndPopulateContext())
            {
                var usuarioService = new UsuarioService(fakeContext);

                // Act
                var result = await usuarioService.CreateUsuario(newUsuarioMock);

                // Assert
                Assert.NotNull(result);
                Assert.True(result.Id != Guid.Empty);
                Assert.Equal(1, fakeContext.Usuarios.Count(x => x.Email == newUsuarioMock.Email));
                Assert.Equal(newUsuarioMock.Apellido, result.Apellido);
                Assert.Equal(newUsuarioMock.Nombre, result.Nombre);
                Assert.Equal(newUsuarioMock.Email, result.Email);
                Assert.Equal(newUsuarioMock.Password, result.Password);
            }
        }

        [Fact]
        public async Task GetUsuario_ShouldReturnUsuario_IfUsiarioExist()
        {
            // Arrange
            var newUsuarioMock = new Usuario
            {
                Apellido = "TestUserApellido",
                Nombre = "TestUserName",
                Email = "Test@UserEmail.com",
                Password = "TestPassword",
                Id = Guid.NewGuid()
            };

            using (var fakeContext = await GenerateAndPopulateContext())
            {
                await fakeContext.AddAsync(newUsuarioMock);
                await fakeContext.SaveChangesAsync();
                var usuarioService = new UsuarioService(fakeContext);

                // Act
                var result = await usuarioService.GetUsuario(newUsuarioMock.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(newUsuarioMock.Apellido, result.Apellido);
                Assert.Equal(newUsuarioMock.Nombre, result.Nombre);
                Assert.Equal(newUsuarioMock.Email, result.Email);
                Assert.Equal(newUsuarioMock.Password, result.Password);
            }
        }

        [Fact]
        public async Task GetUsuario_ShouldReturnNull_IfUsiarioDoesNotExist()
        {
            // Arrange
            using (var fakeContext = await GenerateAndPopulateContext())
            {
                var usuarioService = new UsuarioService(fakeContext);

                // Act
                var result = await usuarioService.GetUsuario(Guid.NewGuid());

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public async Task GetUsuarios_ShouldReturnListOfUsuario_IfUsiariosExist()
        {
            // Arrange
            var usuariosMock = new List<Usuario>
            {
                new Usuario
                {
                    Apellido = "Apellido1",
                    Nombre = "Nombre1",
                    Email = "Nombre1@Apellido1.com",
                    Password = "TestPassword"
                },
                new Usuario
                {
                    Apellido = "Apellido2",
                    Nombre = "Nombre2",
                    Email = "Nombre2@Apellido2.com",
                    Password = "TestPassword"
                }
            };

            using (var fakeContext = await GenerateAndPopulateContext())
            {
                await fakeContext.Usuarios.AddRangeAsync(usuariosMock);

                await fakeContext.SaveChangesAsync();
                var usuarioService = new UsuarioService(fakeContext);

                // Act
                var result = await usuarioService.GetUsuarios();

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal(usuariosMock.Count, result.Count);
            }
        }

        [Fact]
        public async Task GetUsuarios_ShouldReturnEmptyList_IfUsiariosDoesNotExist()
        {
            // Arrange
            using (var fakeContext = await GenerateAndPopulateContext())
            {
                var usuarioService = new UsuarioService(fakeContext);

                // Act
                var result = await usuarioService.GetUsuarios();

                // Assert
                Assert.NotNull(result);
                Assert.Empty(result);
            }
        }

        [Fact]
        public async Task UpdateUsuario_ShouldReturnUsuario_IfUsiarioExist()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var usuarioMock = new Usuario
            {
                Apellido = "TestUserApellido",
                Nombre = "TestUserName",
                Email = "Test@UserEmail.com",
                Password = "TestPassword",
                Id = userId
            };
            var updatedUsuarioMock = new Usuario
            {
                Apellido = "UpdatedTestUserApellido",
                Nombre = "UpdatedTestUserName",
                Email = "UpdatedTest@UserEmail.com",
                Password = "UpdatedTestPassword",
            };

            using (var fakeContext = await GenerateAndPopulateContext())
            {
                await fakeContext.AddAsync(usuarioMock);
                await fakeContext.SaveChangesAsync();
                var usuarioService = new UsuarioService(fakeContext);

                // Act
                var result = await usuarioService.UpdateUsuario(userId, updatedUsuarioMock);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(updatedUsuarioMock.Apellido, result.Apellido);
                Assert.Equal(updatedUsuarioMock.Nombre, result.Nombre);
                Assert.Equal(updatedUsuarioMock.Email, result.Email);
                Assert.Equal(updatedUsuarioMock.Password, result.Password);
            }
        }

        [Fact]
        public async Task UpdateUsuario_ShouldThrowException_IfUsiarioDoesNotExist()
        {
            var updatedUsuarioMock = new Usuario
            {
                Apellido = "UpdatedTestUserApellido",
                Nombre = "UpdatedTestUserName",
                Email = "UpdatedTest@UserEmail.com",
                Password = "UpdatedTestPassword",
            };

            // Arrange
            using (var fakeContext = await GenerateAndPopulateContext())
            {
                var usuarioService = new UsuarioService(fakeContext);

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(async () => await usuarioService.UpdateUsuario(Guid.NewGuid(), updatedUsuarioMock));
            }
        }

        [Fact]
        public async Task UpdateUsuario_ShouldCompleteOk_IfUsiarioExist()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var usuarioMock = new Usuario
            {
                Apellido = "TestUserApellido",
                Nombre = "TestUserName",
                Email = "Test@UserEmail.com",
                Password = "TestPassword",
                Id = userId
            };

            using (var fakeContext = await GenerateAndPopulateContext())
            {
                await fakeContext.AddAsync(usuarioMock);
                await fakeContext.SaveChangesAsync();
                var usuarioService = new UsuarioService(fakeContext);

                // Act
                await usuarioService.DeleteUsuario(userId);

                // Assert
                Assert.Null(await fakeContext.Usuarios.FirstOrDefaultAsync(u => u.Id == userId));
            }
        }

        [Fact]
        public async Task DeleteUser_ShouldThrowException_IfUsiarioDoesNotExist()
        {
            var updatedUsuarioMock = new Usuario
            {
                Apellido = "UpdatedTestUserApellido",
                Nombre = "UpdatedTestUserName",
                Email = "UpdatedTest@UserEmail.com",
                Password = "UpdatedTestPassword",
            };

            // Arrange
            using (var fakeContext = await GenerateAndPopulateContext())
            {
                var usuarioService = new UsuarioService(fakeContext);

                // Assert
                await Assert.ThrowsAsync<InvalidOperationException>(async () => await usuarioService.UpdateUsuario(Guid.NewGuid(), updatedUsuarioMock));
            }
        }

        private async Task<MyRestfullAppContext> GenerateAndPopulateContext()
        {
            var fakeContext = new FakeDatabaseContextBuilder().Build();

            return fakeContext;
        }
    }
}
