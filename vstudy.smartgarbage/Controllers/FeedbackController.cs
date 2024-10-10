using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.ViewModel;
using vstudy.smartgarbage.Model;
using Microsoft.AspNetCore.Authorization;

namespace vstudy.smartgarbage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "OPER,ADMIN")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FeedbackCadastroVM>> Get()
        {
            var feedbacks = _service.ListarFeedbacks();
            var viewModelList = _mapper.Map<IEnumerable<FeedbackCadastroVM>>(feedbacks);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<FeedbackCadastroVM> Get(int id)
        {
            var feedback = _service.ObterFeedbacksPorId(id);
            if (feedback == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<FeedbackCadastroVM>(feedback);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] FeedbackCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = _mapper.Map<FeedbackModel>(viewModel);
            _service.CriarFeedbacks(feedback);
            return CreatedAtAction(nameof(Get), new { id = feedback.FeedBackId }, feedback);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] FeedbackCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedbackExistente = _service.ObterFeedbacksPorId(id);
            if (feedbackExistente == null)
            {
                return NotFound();
            }

            var feedbackAtualizado = _mapper.Map(viewModel, feedbackExistente);
            _service.AtualizarFeedbacks(feedbackAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var feedback = _service.ObterFeedbacksPorId(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _service.DeletarFeedbacks(id);
            return NoContent();
        }
    }
}
