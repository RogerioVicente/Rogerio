using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace MVC_BD.Models
{
    public class ClienteModel : IDisposable
    {
        private OleDbConnection conexao;
        public ClienteModel()
        {
            string strCon = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Estudo";
            conexao = new OleDbConnection(strCon);
            conexao.Open();
        }

        public List<Cliente> ListarClientes()
        {
            OleDbCommand comando = new OleDbCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT id, cpf, nome FROM clientes";

            OleDbDataReader reader = comando.ExecuteReader();

            Cliente cli;
            List<Cliente> lstCli = new List<Cliente>();

            while (reader.Read())
            {
                cli = new Cliente();
                cli.Id = Convert.ToInt16(reader["Id"]);
                cli.Cpf = reader["Cpf"].ToString();
                cli.Nome = reader["Nome"].ToString();
                lstCli.Add(cli);
            }

            return lstCli;
        }

        public Cliente SelecionarCliente(int id)
        {
            OleDbCommand comando = new OleDbCommand();
            comando.Connection = conexao;
            comando.CommandText = $"SELECT id, cpf, nome FROM clientes WHERE id={id}";

            OleDbDataReader reader = comando.ExecuteReader();
            Cliente cli = null;

            if (reader.HasRows)
            {
                reader.Read();
                cli = new Cliente();
                cli.Id = Convert.ToInt16(reader["Id"]);
                cli.Cpf = reader["Cpf"].ToString();
                cli.Nome = reader["Nome"].ToString();
            }

            return cli;
        }

        public void InserirCliente(Cliente cliente)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexao;
            cmd.CommandText = $"INSERT INTO clientes VALUES('{cliente.Cpf}', '{cliente.Nome}')";
            cmd.ExecuteNonQuery();
        }

        public void EditarCliente(Cliente cliente)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexao;
            cmd.CommandText = $"UPDATE clientes SET nome='{cliente.Nome}',cpf='{cliente.Cpf}' WHERE id={cliente.Id}";

            cmd.ExecuteNonQuery();
        }

        public void DeletarCliente(int id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexao;
            cmd.CommandText = $"DELETE FROM clientes WHERE Id={id}";

            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            conexao.Close();
        }
    }
}