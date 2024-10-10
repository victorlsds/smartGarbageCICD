using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using vstudy.smartgarbage.Controllers;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.ViewModel;
using Xunit;

namespace vstudy.smartgarbage.tests
{
    public class ResiduoColetaControllerTests
    {
        private readonly Mock<IResiduoColetaService> _mockResiduoColetaService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ResiduoColetaController _controller;

        public ResiduoColetaControllerTests()
        {
            _mockResiduoColetaService = new Mock<IResiduoColetaService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ResiduoColetaController(_mockResiduoColetaService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfResiduos()
        {
            // Arrange
            var residuos = new List<ResiduoColetaModel>
            {
                new ResiduoColetaModel { ResiduoColetaId = 1, TipoResiduo = "Radioativo" },
                new ResiduoColetaModel { ResiduoColetaId = 2, TipoResiduo = "ORGANICO" }
            };

            _mockResiduoColetaService.Setup(service => service.ListarResiduos()).Returns(residuos);

            var residuosVM = new List<ResiduoColetaCadastroVM>
            {
                new ResiduoColetaCadastroVM { ResiduoColetaId = 1, TipoResiduo = "Radioativo" },
                new ResiduoColetaCadastroVM { ResiduoColetaId = 2, TipoResiduo = "ORGANICO" }
            };

            _mockMapper.Setup(m => m.Map<IEnumerable<ResiduoColetaCadastroVM>>(It.IsAny<IEnumerable<ResiduoColetaModel>>()))
                       .Returns(residuosVM);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<ResiduoColetaCadastroVM>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenResiduoDoesNotExist()
        {
            // Arrange
            _mockResiduoColetaService.Setup(service => service.ObterResiduosPorId(It.IsAny<int>())).Returns<ResiduoColetaModel>(null);

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithResiduo()
        {
            // Arrange
            var residuo = new ResiduoColetaModel { ResiduoColetaId = 1, TipoResiduo = "Radioativo" };
            _mockResiduoColetaService.Setup(service => service.ObterResiduosPorId(1)).Returns(residuo);

            var residuoVM = new ResiduoColetaCadastroVM { ResiduoColetaId = 1, TipoResiduo = "Radioativo" };
            _mockMapper.Setup(m => m.Map<ResiduoColetaCadastroVM>(residuo)).Returns(residuoVM);

            // Act
            var result = _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<ResiduoColetaCadastroVM>(okResult.Value);
            Assert.Equal(residuoVM, model);
        }

        [Fact]
        public void Post_ReturnsCreatedAtAction_WithNewResiduo()
        {
            // Arrange
            var residuoVM = new ResiduoColetaCadastroVM { TipoResiduo = "Radioativo" };
            var residuo = new ResiduoColetaModel { ResiduoColetaId = 1, TipoResiduo = "Radioativo" };

            _mockMapper.Setup(m => m.Map<ResiduoColetaModel>(residuoVM)).Returns(residuo);
            _mockResiduoColetaService.Setup(service => service.CriarResiduos(residuo));

            // Act
            var result = _controller.Post(residuoVM);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(residuo.ResiduoColetaId, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(residuo, createdAtActionResult.Value);
        }

        [Fact]
        public void Put_ReturnsNoContent_WhenResiduoIsUpdated()
        {
            // Arrange
            var residuoVM = new ResiduoColetaCadastroVM { TipoResiduo = "Residuo Updated" };
            var residuoExistente = new ResiduoColetaModel { ResiduoColetaId = 1, TipoResiduo = "Radioativo" };

            _mockResiduoColetaService.Setup(service => service.ObterResiduosPorId(1)).Returns(residuoExistente);
            _mockMapper.Setup(m => m.Map(residuoVM, residuoExistente)).Returns(residuoExistente);

            // Act
            var result = _controller.Put(1, residuoVM);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenResiduoIsDeleted()
        {
            // Arrange
            var residuo = new ResiduoColetaModel { ResiduoColetaId = 1, TipoResiduo = "Radioativo" };

            _mockResiduoColetaService.Setup(service => service.ObterResiduosPorId(1)).Returns(residuo);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenResiduoDoesNotExist()
        {
            // Arrange
            _mockResiduoColetaService.Setup(service => service.ObterResiduosPorId(It.IsAny<int>())).Returns<ResiduoColetaModel>(null);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
