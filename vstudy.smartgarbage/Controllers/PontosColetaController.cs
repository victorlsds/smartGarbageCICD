using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.ViewModel;

namespace vstudy.smartgarbage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "OPER,ADMIN")]
    public class PontosColetaController : ControllerBase
    {
        private readonly IPontosColetaService _service;
        private readonly IMapper _mapper;

        public PontosColetaController(IPontosColetaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PontosColetaVisualizacaoVM>> Get()
        {
            var pontos = _service.ListarPontosColeta();
            var viewModelList = _mapper.Map<IEnumerable<PontosColetaVisualizacaoVM>>(pontos);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public ActionResult<PontosColetaVisualizacaoVM> Get(int id)
        {
            var ponto = _service.ObterPontoColetaPorId(id);
            if (ponto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<PontosColetaVisualizacaoVM>(ponto);
            return Ok(viewModel);
        }
    }
}