using Microsoft.AspNetCore.Mvc;
using WebAPIArenaCactus.BLL;

namespace WebAPIArenaCactus.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        // GET api/values
        [HttpGet("Listar")]
        public List<Models.Clientes> ListarClientes()
        {
            return new BLLClientes().ListarClientes();
        }
        [HttpGet("Login")]
        public int Login(string email, string senha)
        {
            return new BLLClientes().Login(email, senha);
        }
        [HttpPost("CadastrarCliente")]
        public string CadastrarCliente(string nome, string email, string cpf, string telefone, string senha, string funcao)
        {
            return new BLLClientes().CadastrarCliente(nome, email, cpf, telefone, senha, funcao);
        }
    }
}
