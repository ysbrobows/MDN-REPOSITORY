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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace MDN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ApplicationDbContext context, IHostingEnvironment IHostingEnvironment, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _environment = IHostingEnvironment;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //   [Route("listagem/{uf:int?}")]
        public async Task<IActionResult> Index()
        {
            var Anuncios = CarregarAnuncios();
            if (User.Identity.IsAuthenticated)
            {
                ViewData["UFS"] = new SelectList(_context.Set<T003_UF>(), "T003_ID_UF", "T003_NO_UF", Anuncios[0].T003_ID_UF);
            }
            else
            {
                ViewData["UFS"] = new SelectList(_context.Set<T003_UF>(), "T003_ID_UF", "T003_NO_UF");
            }
            //return PartialView("_ItemGrid", Anuncios);
            return View(Anuncios);
        }

        public async Task UpdateUserLocation(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var identity = User.Identity as ClaimsIdentity;

                // check for existing claim and remove it
                var existingClaim = identity.FindFirst("T003_ID_UF");
                if (existingClaim != null)
                {
                    await _userManager.RemoveClaimAsync(user, existingClaim);
                }


                Claim claim = new Claim("T003_ID_UF", id.ToString());

                await _userManager.AddClaimAsync(user, claim);
                await _signInManager.SignInAsync(user, false);
            }
        }
        public List<AnuncioGridVM> CarregarAnuncios()
        {
            List<AnuncioGridVM> Anuncios = new List<AnuncioGridVM>();
            IQueryable<AnuncioGridVM> PRODUTOS;

            var identity = User.Identity as ClaimsIdentity;
            if (User.Identity.IsAuthenticated)
            {
                var Claim = identity.Claims.FirstOrDefault(c => c.Type == "T003_ID_UF");
                PRODUTOS = _context.Set<T001_PRODUTO>().Where(x => x.T003_ID_UF == int.Parse(Claim.Value)).Select(
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
                    User_Id = x.User_Id
                }).Take(10);
            }
            else
            {
                PRODUTOS = _context.Set<T001_PRODUTO>().Select(
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
                       User_Id = x.User_Id
                   }).Take(10);
            }
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
            return Anuncios;
        }
        public async Task<IActionResult> CarregarAnunciosPorUf(int uf)
        {
            List<AnuncioGridVM> Anuncios = new List<AnuncioGridVM>();
            IQueryable<AnuncioGridVM> PRODUTOS;

            if (User.Identity.IsAuthenticated)
            {
                await UpdateUserLocation(uf);
            }
            PRODUTOS = _context.Set<T001_PRODUTO>().Where(x => x.T003_ID_UF == uf).Select(
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
                User_Id = x.User_Id
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
            return PartialView("_ItemGrid", Anuncios);
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
