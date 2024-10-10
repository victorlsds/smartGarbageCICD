using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vstudy.smartgarbage.Data.Context;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.ViewModel;

namespace vstudy.smartgarbage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "OPER,ADMIN")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoColetaService _service;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public AgendamentoController(DatabaseContext context, IAgendamentoColetaService service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AgendamentoVisualizacaoVM>> Get()
        {
            var agendamentos = _service.ListarAgendamentos();
            var viewModelList = _mapper.Map<IEnumerable<AgendamentoVisualizacaoVM>>(agendamentos);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<AgendamentoVisualizacaoVM> Get(int id)
        {
            var agendamento = _service.ObterAgendamentosPorId(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<AgendamentoVisualizacaoVM>(agendamento);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AgendamentoCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamento = _mapper.Map<AgendamentoColetaModel>(viewModel);
            _service.CriarAgendamento(agendamento);

            var agendamentoVisualizacao = _mapper.Map<AgendamentoVisualizacaoVM>(agendamento);
            return CreatedAtAction(nameof(Get), new { id = agendamento.AgendamentoId }, agendamentoVisualizacao);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AgendamentoCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamentoExistente = _service.ObterAgendamentosPorId(id);
            if (agendamentoExistente == null)
            {
                return NotFound();
            }

            var agendamentoAtualizado = _mapper.Map(viewModel, agendamentoExistente);
            _service.AtualizarAgendamento(agendamentoAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var agendamento = _service.ObterAgendamentosPorId(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _service.DeletarAgendamento(id);
            return NoContent();
        }
    }
}