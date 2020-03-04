using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_mngr_10.Models;
using data_mngr_10.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace data_mngr_10.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaInMemoryRepository _pessoaRepository;


        public PessoaController()
        {
            _pessoaRepository = new PessoaInMemoryRepository();
        }


        public IActionResult Index()
        {
            var pessoas = _pessoaRepository.GetAll();
            return View(pessoas);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel newPessoaModel)
        {
            try
            {
                // TODO: Add insert logic here
                _pessoaRepository.Add(newPessoaModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}