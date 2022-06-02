using DevIO.Site.Data;
using DevIO.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Natalia",
                DataNascimento = DateTime.Now,
                Email = "natspindola@hotmail.com"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            return View();
        }
    }
}
