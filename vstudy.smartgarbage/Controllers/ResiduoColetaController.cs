using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.ViewModel;

namespace vstudy.smartgarbage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "OPER,ADMIN")]
    public class ResiduoColetaController : ControllerBase
    {
        private readonly IResiduoColetaService _service;
        private readonly IMapper _mapper;

        public ResiduoColetaController(IResiduoColetaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResiduoColetaCadastroVM>> Get()
        {
            var residuos = _service.ListarResiduos();
            var viewModelList = _mapper.Map<IEnumerable<ResiduoColetaCadastroVM>>(residuos);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<ResiduoColetaCadastroVM> Get(int id)
        {
            var residuo = _service.ObterResiduosPorId(id);
            if (residuo == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ResiduoColetaCadastroVM>(residuo);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ResiduoColetaCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var residuo = _mapper.Map<ResiduoColetaModel>(viewModel);
            _service.CriarResiduos(residuo);
            return CreatedAtAction(nameof(Get), new { id = residuo.ResiduoColetaId }, residuo);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ResiduoColetaCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamentoExistente = _service.ObterResiduosPorId(id);
            if (agendamentoExistente == null)
            {
                return NotFound();
            }

            var agendamentoAtualizado = _mapper.Map(viewModel, agendamentoExistente);
            _service.AtualizarResiduos(agendamentoAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var residuo = _service.ObterResiduosPorId(id);
            if (residuo == null)
            {
                return NotFound();
            }

            _service.DeletarResiduos(id);
            return NoContent();
        }
    }
}

