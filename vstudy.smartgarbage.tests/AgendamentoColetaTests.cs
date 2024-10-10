using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using vstudy.smartgarbage.Controllers;
using vstudy.smartgarbage.Data.Context;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.ViewModel;
using Xunit;

namespace vstudy.smartgarbage.tests
{
    public class AgendamentoColetaTests
    {
        private readonly Mock<IAgendamentoColetaService> _mockAgendamentoService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AgendamentoController _controller;

        public AgendamentoColetaTests()
        {
            _mockAgendamentoService = new Mock<IAgendamentoColetaService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AgendamentoController(null, _mockAgendamentoService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfAgendamentos()
        {
            // Arrange
            var agendamentos = new List<AgendamentoColetaModel>
            {
                new AgendamentoColetaModel { AgendamentoId = 1, Status = "PENDENTE" },
                new AgendamentoColetaModel { AgendamentoId = 2, Status = "CONCLUÍDO" }
            };

            _mockAgendamentoService.Setup(service => service.ListarAgendamentos()).Returns(agendamentos);

            var agendamentosVM = new List<AgendamentoVisualizacaoVM>
            {
                new AgendamentoVisualizacaoVM { AgendamentoId = 1, Status = "PENDENTE" },
                new AgendamentoVisualizacaoVM { AgendamentoId = 2, Status = "CONCLUÍDO" }
            };

            _mockMapper.Setup(m => m.Map<IEnumerable<AgendamentoVisualizacaoVM>>(It.IsAny<IEnumerable<AgendamentoColetaModel>>()))
                       .Returns(agendamentosVM);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<AgendamentoVisualizacaoVM>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenAgendamentoDoesNotExist()
        {
            // Arrange
            _mockAgendamentoService.Setup(service => service.ObterAgendamentosPorId(It.IsAny<int>())).Returns<AgendamentoColetaModel>(null);

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Post_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Model state is invalid");

            // Act
            var result = _controller.Post(new AgendamentoCadastroVM());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ReturnsCreatedAtAction_WhenAgendamentoIsCreated()
        {
            // Arrange
            var agendamentoCadastroVM = new AgendamentoCadastroVM { /* properties */ };
            var agendamento = new AgendamentoColetaModel { AgendamentoId = 1 };

            _mockMapper.Setup(m => m.Map<AgendamentoColetaModel>(agendamentoCadastroVM)).Returns(agendamento);
            _mockAgendamentoService.Setup(service => service.CriarAgendamento(agendamento));

            var agendamentoVisualizacaoVM = new AgendamentoVisualizacaoVM { AgendamentoId = 1 };
            _mockMapper.Setup(m => m.Map<AgendamentoVisualizacaoVM>(agendamento)).Returns(agendamentoVisualizacaoVM);

            // Act
            var result = _controller.Post(agendamentoCadastroVM);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.Get), createdAtActionResult.ActionName);
            Assert.Equal(agendamentoVisualizacaoVM, createdAtActionResult.Value);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenAgendamentoDoesNotExist()
        {
            // Arrange
            _mockAgendamentoService.Setup(service => service.ObterAgendamentosPorId(It.IsAny<int>())).Returns<AgendamentoColetaModel>(null);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenAgendamentoIsDeleted()
        {
            // Arrange
            var agendamento = new AgendamentoColetaModel { AgendamentoId = 1 };
            _mockAgendamentoService.Setup(service => service.ObterAgendamentosPorId(1)).Returns(agendamento);
            _mockAgendamentoService.Setup(service => service.DeletarAgendamento(1));

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
