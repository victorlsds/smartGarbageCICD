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
    [Authorize(Roles = "ADMIN")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioVisualizacaoVM>> Get()
        {
            var usuarios = _service.ListarUsuarios();
            var viewModelList = _mapper.Map<IEnumerable<UsuarioVisualizacaoVM>>(usuarios);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioVisualizacaoVM> Get(int id)
        {
            var usuario = _service.ObterUsuariosPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<UsuarioVisualizacaoVM>(usuario);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = _mapper.Map<UsuarioModel>(viewModel);
            _service.CriarUsuarios(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioCadastroVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioExistente = _service.ObterUsuariosPorId(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            var usuarioAtualizado = _mapper.Map(viewModel, usuarioExistente);
            _service.AtualizarUsuarios(usuarioAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = _service.ObterUsuariosPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _service.DeletarUsuarios(id);
            return NoContent();
        }
    }
}
