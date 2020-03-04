using data_mngr_10.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace data_mngr_10.Repositorys
{
    public class PessoaMdfRepository
    {

        public IEnumerable<PessoaModel> GetAll()
        {
            var connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samuel.belo\source\repos\data-mngr-10\data-mngr-10\App_data\MvcAdoNet.mdf;Integrated Security=True";

            var cmdText = $"SELECT Nome, Id, Nascimento FROM Pessoa";

            using (var sqlConnection = new SqlConnection(connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        var idColumnIndex = reader.GetOrdinal("ID");
                        var nomeColumnIndex = reader.GetOrdinal("Nome");
                        var nascimentoColumnIndex = reader.GetOrdinal("Nascimento");
                        while (reader.Read())
                        {
                            var id = reader.GetFieldValue<int>(idColumnIndex);
                            var nome = reader.GetFieldValue<string>(nomeColumnIndex);
                            var nascimento= reader.GetFieldValue<DateTime>(nomeColumnIndex);
                            var novaPessoa = new Pessoa
                            {
                                Id = id,
                                Nome = nome,
                                Nascimento = nascimento
                            }
                        }
                    }
                }
            }
            return pessoas;
        }


    }
}
