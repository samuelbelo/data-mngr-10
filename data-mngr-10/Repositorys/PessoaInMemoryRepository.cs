using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_mngr_10.Models;

namespace data_mngr_10.Repositorys
{
    public class PessoaInMemoryRepository
    {
        
        private static readonly List<PessoaModel> _pessoas
            = new List<PessoaModel>
            {
                new PessoaModel
                {
                    Id = 1,
                    Nome = "Pessoa Teste",
                    Nascimento = new DateTime(1996, 12, 06)
                }
            };
        public List<PessoaModel> GetAll()
        {
            return _pessoas;
        }

        public void Add(PessoaModel newPessoaModel)
        {
            _pessoas.Add(newPessoaModel);
        }
    }
}
