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
    public class PontosColetaControllerTests
    {
        private readonly Mock<IPontosColetaService> _mockPontosColetaService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PontosColetaController _controller;

        public PontosColetaControllerTests()
        {
            _mockPontosColetaService = new Mock<IPontosColetaService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new PontosColetaController(_mockPontosColetaService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfPontosColeta()
        {
            // Arrange
            var pontos = new List<PontosColetaModel>
            {
                new PontosColetaModel { PontoId = 1, Logradouro = "CARMO DE SOUZA CAMPOS" },
                new PontosColetaModel { PontoId = 2, Logradouro = "BRIGADEIRO FARIA LIMA" }
            };

            _mockPontosColetaService.Setup(service => service.ListarPontosColeta()).Returns(pontos);

            var pontosVM = new List<PontosColetaVisualizacaoVM>
            {
                new PontosColetaVisualizacaoVM { PontoId = 1, Logradouro = "CARMO DE SOUZA CAMPOS" },
                new PontosColetaVisualizacaoVM { PontoId = 2, Logradouro = "BRIGADEIRO FARIA LIMA" }
            };

            _mockMapper.Setup(m => m.Map<IEnumerable<PontosColetaVisualizacaoVM>>(It.IsAny<IEnumerable<PontosColetaModel>>()))
                       .Returns(pontosVM);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<PontosColetaVisualizacaoVM>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenPontoColetaDoesNotExist()
        {
            // Arrange
            _mockPontosColetaService.Setup(service => service.ObterPontoColetaPorId(It.IsAny<int>())).Returns<PontosColetaModel>(null);

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithPontoColeta()
        {
            // Arrange
            var ponto = new PontosColetaModel { PontoId = 1, Logradouro = "CARMO DE SOUZA CAMPOS" };
            _mockPontosColetaService.Setup(service => service.ObterPontoColetaPorId(1)).Returns(ponto);

            var pontoVM = new PontosColetaVisualizacaoVM { PontoId = 1, Logradouro = "CARMO DE SOUZA CAMPOS" };
            _mockMapper.Setup(m => m.Map<PontosColetaVisualizacaoVM>(ponto)).Returns(pontoVM);

            // Act
            var result = _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<PontosColetaVisualizacaoVM>(okResult.Value);
            Assert.Equal(pontoVM, model);
        }
    }
}
