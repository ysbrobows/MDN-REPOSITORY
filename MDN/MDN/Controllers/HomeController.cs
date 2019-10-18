using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MDN.Models;
using MDN.ViewModels;
using MDN.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using MDN.Data;
using System.IO;

namespace MDN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;

        public HomeController(ApplicationDbContext context, IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<AnuncioGridVM> Anuncios = new List<AnuncioGridVM>();

            var PRODUTOS = _context.Set<T001_PRODUTO>().Select(
                x => new AnuncioGridVM
                {
                    T001_ID_PRODUTO = x.T001_ID_PRODUTO,
                    T001_TITULO = x.T001_TITULO,
                    T001_DESCRICAO = x.T001_DESCRICAO,
                    T001_PRECO = x.T001_PRECO,
                    T001_DT_CRIACAO = x.T001_DT_CRIACAO,
                    T001_ATIVO = x.T001_ATIVO,
                    T003_ID_UF = x.T003_ID_UF,
                    T002_ID_CATEGORIA = x.T002_ID_CATEGORIA,
                    UserName = x.UserName
                }).Take(10);

            foreach (var item in PRODUTOS)
            {
                String fullPath = String.Concat(_environment.WebRootPath, "\\uploadImages\\", item.T001_ID_PRODUTO);
                if (Directory.Exists(fullPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(fullPath);
                    var NomeImagem = dir.GetFiles().Select(x => x.Name).FirstOrDefault();
                    item.caminhoImagem = "https://" + HttpContext.Request.Host.Value + "/uploadImages/" + item.T001_ID_PRODUTO + "/" + NomeImagem;
                    Anuncios.Add(item);
                }
                else
                {
                    item.caminhoImagem = "https://" + HttpContext.Request.Host.Value + "/uploadImages/semfoto.jpg";
                    Anuncios.Add(item);
                }
            }


            return View(Anuncios);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
