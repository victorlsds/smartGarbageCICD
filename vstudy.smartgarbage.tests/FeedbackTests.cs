using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using vstudy.smartgarbage.Controllers;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.ViewModel;
using Xunit;

namespace vstudy.smartgarbage.tests
{
    public class FeedbackControllerTests
    {
        private readonly Mock<IFeedbackService> _mockFeedbackService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly FeedbackController _controller;

        public FeedbackControllerTests()
        {
            _mockFeedbackService = new Mock<IFeedbackService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new FeedbackController(_mockFeedbackService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfFeedbacks()
        {
            // Arrange
            var feedbacks = new List<FeedbackModel>
            {
                new FeedbackModel { FeedBackId = 1, Mensagem = "BOM" },
                new FeedbackModel { FeedBackId = 2, Mensagem = "RUIM" }
            };

            _mockFeedbackService.Setup(service => service.ListarFeedbacks()).Returns(feedbacks);

            var feedbacksVM = new List<FeedbackCadastroVM>
            {
                new FeedbackCadastroVM { FeedBackId = 1, Mensagem = "BOM" },
                new FeedbackCadastroVM { FeedBackId = 2, Mensagem = "RUIM" }
            };

            _mockMapper.Setup(m => m.Map<IEnumerable<FeedbackCadastroVM>>(It.IsAny<IEnumerable<FeedbackModel>>()))
                       .Returns(feedbacksVM);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<FeedbackCadastroVM>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenFeedbackDoesNotExist()
        {
            // Arrange
            _mockFeedbackService.Setup(service => service.ObterFeedbacksPorId(It.IsAny<int>())).Returns<FeedbackModel>(null);

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
            var result = _controller.Post(new FeedbackCadastroVM());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenFeedbackDoesNotExist()
        {
            // Arrange
            _mockFeedbackService.Setup(service => service.ObterFeedbacksPorId(It.IsAny<int>())).Returns<FeedbackModel>(null);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenFeedbackIsDeleted()
        {
            // Arrange
            var feedback = new FeedbackModel { FeedBackId = 1 };
            _mockFeedbackService.Setup(service => service.ObterFeedbacksPorId(1)).Returns(feedback);
            _mockFeedbackService.Setup(service => service.DeletarFeedbacks(1));

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
