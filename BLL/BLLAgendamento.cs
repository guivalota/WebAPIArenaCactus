using WebAPIArenaCactus.DAL;
using WebAPIArenaCactus.Models;

namespace WebAPIArenaCactus.BLL
{
    public class BLLAgendamento
    {
        public List<Quadra> ListarQuadras(int idCredenciado)
        {
            return new DALAgendamento().ListarQuadras(idCredenciado);
        }

        public string Cadastrar(DateTime data,  int idCredenciado, int idCliente, int idQuadra)
        {
            return new DALAgendamento().Cadastrar(data, idCredenciado, idCliente, idQuadra);
        }
    }
}
