using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_mngr_10.Models;
using Microsoft.AspNetCore.Mvc;

namespace data_mngr_10.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
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