using Microsoft.AspNetCore.Mvc;
using WebAPIArenaCactus.BLL;

namespace WebAPIArenaCactus.Controllers
{
    [Route("api/[controller]")]
    public class AgendamentoController : Controller
    {
        [HttpGet("ListarQuadras")]
        public List<Models.Quadra> ListarQuadras(int idCredenciado)
        {
            return new BLLAgendamento().ListarQuadras(idCredenciado);
        }
        [HttpPost("Cadastrar")]
        public string Cadastrar(DateTime data, int idCredenciado, int idCliente, int idQuadra)
        {
            return new BLLAgendamento().Cadastrar(data, idCredenciado, idCliente, idQuadra);
        }
    }
}
