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

            var aluno2 = _contexto.Alunos.Find(aluno.Id); //pesquisar por id
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "natspindola@hotmail.com"); //pesquisa o primeiro aluno com esse email
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Natalia"); //pesquisa todos os alunos com esse nome

            aluno.Nome = "João"; //alterar nome
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno); //remover aluno
            _contexto.SaveChanges();

            return View();
        }
    }
}
