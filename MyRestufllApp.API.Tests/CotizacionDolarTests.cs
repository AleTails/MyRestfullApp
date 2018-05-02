using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestfullApp.API.Services;
using Xunit;

namespace MyRestufllApp.API.Tests
{
    public class CotizacionDolarTests
    {
        [Fact]
        public async Task CotizacionDolar_ShouldRetunr_Ok()
        {
            // Arrange
            var cotizacionDolarService = new CotizacionDolarService();

            // Act
            var result = await cotizacionDolarService.Cotizar();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
