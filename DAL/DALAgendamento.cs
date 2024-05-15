using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using WebAPIArenaCactus.Models;

namespace WebAPIArenaCactus.DAL
{
    public class DALAgendamento
    {
        public List<Quadra> ListarQuadras(int idCredenciado)
        {
            List<Quadra> lsQuadras = new List<Quadra>();

            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT idQuadra, nome, valor, idCredenciado FROM quadra where idCredenciado = @idCredenciado");
                    cmd.Parameters.AddWithValue("@idCredenciado", idCredenciado);
                    cmd.Connection = conn;
                    using (var reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Quadra quadra = new Quadra()
                            {
                                idQuadra = (int)reader["idQuadra"],
                                nome = reader["Nome"] != System.DBNull.Value ? reader["Nome"].ToString() : null,
                                valor = (double)reader["valor"],
                                idCredenciado = (int)reader["idCredenciado"],
                            };
                            lsQuadras.Add(quadra);
                        }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return lsQuadras;
        }

        public string Cadastrar(DateTime data, int idCredenciado, int idCliente, int idQuadra)
        {
            string retorno = "";
            //Verificar Disponibilidade
            if (VerificarDisponibilidadeQuadra(data, idQuadra, idCredenciado))
            {
                retorno = "Quadra indisponivel nesse horario";
                return retorno;
            }
            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO agendamento (idquadra, idcliente, idcredenciado, data) values " +
                        "(@IdQuadra, @IdCliente, @IdCredenciado, @Data)");
                    cmd.Parameters.AddWithValue("@IdQuadra", idQuadra);
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("@IdCredenciado", idCredenciado);
                    cmd.Parameters.AddWithValue("@Data", data);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    retorno = "Agendamento cadastrado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                retorno = "Erro ao cadastrar o agaendamento - "+ex.Message;
                throw (ex);
            }

            return retorno;
        }

        public bool VerificarDisponibilidadeQuadra(DateTime data, int idQuadra, int idCredenciado)
        {
            bool retorno = false;
            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT 1 FROM agendamento where data = @Data and idquadra = @IdQuadra and idcredenciado = @IdCredenciado");
                    cmd.Parameters.AddWithValue("@Data", data);
                    cmd.Parameters.AddWithValue("@IdQuadra", idQuadra);
                    cmd.Parameters.AddWithValue("@IdCredenciado", idCredenciado);
                    cmd.Connection = conn;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            retorno = true;
                        }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return retorno;
        }


    }
}
