using MySql.Data.MySqlClient;
using WebAPIArenaCactus.Models;

namespace WebAPIArenaCactus.DAL
{
    public class DALClientes
    {
        public List<Clientes> ListarClientes()
        {
            List<Clientes> lsClientes = new List<Clientes>();

            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT * FROM clientes", conn))
                    using (var reader = cmd.ExecuteReader())

                        while (reader.Read())
                        {
                            Clientes cliente = new Clientes()
                            {
                                IdCliente = (int)reader["idClientes"],
                                Nome = reader["Nome"] != System.DBNull.Value ? reader["Nome"].ToString() : null,
                                Cpf = reader["CPF"] != System.DBNull.Value ? reader["CPF"].ToString() : null,
                                Email = reader["Email"] != System.DBNull.Value ? reader["Email"].ToString() : null,
                                //Senha = (string)reader["senha"],
                                Funcao = reader["Funcao"] != System.DBNull.Value ? reader["Funcao"].ToString() : null,
                                Telefone = reader["Telefone"] != System.DBNull.Value ? reader["Telefone"].ToString() : null
                            };

                            lsClientes.Add(cliente);
                        }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return lsClientes;
        }


        public int Login(string email, string senha)
        {
            int retorno = 0;
            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT idclientes FROM clientes WHERE email = @Email and senha  = @Senha");
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.Connection = conn;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            retorno = (int)reader["idClientes"];
                        }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return retorno;
        }

        public string PegarCliente(int idClientes)
        {
            string retorno = "";
            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT nome FROM clientes WHERE idclientes = @IdCliente");
                    cmd.Parameters.AddWithValue("@IdCliente", idClientes);
                    cmd.Connection = conn;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            retorno = (string)reader["nome"];
                        }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return retorno;
        }


        public string CadastrarCliente(string nome, string email, string cpf, string telefone, string senha, string funcao)
        {
            string retorno = "";
            try
            {
                //Verificar email já cadastrado
                if (VerificarEmailCadastrado(email))
                {
                    retorno = "Email já está utilizado.";
                    return retorno;
                }
                //Verificar CPF já cadastrado
                if (VerificarCPFCadastrado(cpf))
                {
                    retorno = "CPF já cadastrado.";
                    return retorno;
                }
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO clientes (nome, cpf, telefone, email, senha, funcao) values " +
                        "(@Nome, @Cpf, @Telefone, @Email, @Senha, @Funcao)");
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    cmd.Parameters.AddWithValue("@Telefone", telefone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.Parameters.AddWithValue("@Funcao", funcao);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    retorno = "Usuário cadastro com sucesso!";
                }

            }
            catch(Exception ex)
            {
                retorno = "Erro ao cadastrar o Cliente: "+ ex.Message;
                throw ex;
            }
            return retorno;
        }

        private bool VerificarEmailCadastrado(string email)
        {
            bool retorno = false;
            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT 1 FROM clientes where email ='" + email + "'", conn))
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
                throw ex;
            }
            return retorno;
        }

        private bool VerificarCPFCadastrado(string cpf)
        {
            bool retorno = false;
            try
            {
                using (var conn = new MySqlConnection(new Connection().GetConnMySQL()))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT 1 FROM clientes where cpf ='" + cpf + "'", conn))
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
                throw ex;
            }
            return retorno;
        }

    }
}
