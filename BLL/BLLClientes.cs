using WebAPIArenaCactus.DAL;
using WebAPIArenaCactus.Models;

namespace WebAPIArenaCactus.BLL
{
    public class BLLClientes
    {
        public List<Clientes> ListarClientes()
        {
            return new DALClientes().ListarClientes();
        }

        public int Login(string email, string password)
        {
            return new DALClientes().Login(email, password);
        }

        public string CadastrarCliente(string nome, string email, string cpf, string telefone, string senha, string funcao)
        {
            return new DALClientes().CadastrarCliente(nome, email, cpf, telefone, senha, funcao);
        }
    }
}
