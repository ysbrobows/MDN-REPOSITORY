using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MDN.Data;
using MDN.Models.Entities;
using MDN.Helpers;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using MDN.ViewModels;

namespace MDN.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
            filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.T001_PRODUTO.Include(t => t.T002_CATEGORIANavigation).Include(t => t.T003_UFNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t001_PRODUTO = await _context.T001_PRODUTO
                .Include(t => t.T002_CATEGORIANavigation)
                .Include(t => t.T003_UFNavigation)
                .SingleOrDefaultAsync(m => m.T001_ID_PRODUTO == id);
            if (t001_PRODUTO == null)
            {
                return NotFound();
            }

            return View(t001_PRODUTO);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["CATEGORIAS"] = new SelectList(_context.Set<T002_CATEGORIA>(), "T002_ID_CATEGORIA", "T002_NO_CATEGORIA");
            ViewData["UFS"] = new SelectList(_context.Set<T003_UF>(), "T003_ID_UF", "T003_NO_UF");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("T001_ID_PRODUTO,T001_TITULO,T001_DESCRICAO,T001_PRECO,T001_FOTO,T003_ID_UF,T002_ID_CATEGORIA")] T001_PRODUTO t001_PRODUTO)
        {
            if (ModelState.IsValid)
            {
                t001_PRODUTO.UserName =  _context.Users.Single(x => x.UserName == User.Identity.Name).UserName;
               // var id = user.Id;
                _context.Add(t001_PRODUTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CATEGORIAS"] = new SelectList(_context.Set<T002_CATEGORIA>(), "T002_ID_CATEGORIA", "T002_NO_CATEGORIA", t001_PRODUTO.T002_ID_CATEGORIA);
            ViewData["UFS"] = new SelectList(_context.Set<T003_UF>(), "T003_ID_UF", "T003_NO_UF", t001_PRODUTO.T003_ID_UF);
            return View(t001_PRODUTO);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t001_PRODUTO = await _context.T001_PRODUTO.SingleOrDefaultAsync(m => m.T001_ID_PRODUTO == id);
            if (t001_PRODUTO == null)
            {
                return NotFound();
            }
            ViewData["T002_ID_CATEGORIA"] = new SelectList(_context.Set<T002_CATEGORIA>(), "T002_ID_CATEGORIA", "T002_ID_CATEGORIA", t001_PRODUTO.T002_ID_CATEGORIA);
            ViewData["T003_ID_UF"] = new SelectList(_context.Set<T003_UF>(), "T003_ID_UF", "T003_ID_UF", t001_PRODUTO.T003_ID_UF);
            return View(t001_PRODUTO);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("T001_ID_PRODUTO,T001_TITULO,T001_DESCRICAO,T001_PRECO,T001_FOTO,T003_ID_UF,T002_ID_CATEGORIA")] T001_PRODUTO t001_PRODUTO)
        {
            if (id != t001_PRODUTO.T001_ID_PRODUTO)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t001_PRODUTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T001_PRODUTOExists(t001_PRODUTO.T001_ID_PRODUTO))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["T002_ID_CATEGORIA"] = new SelectList(_context.Set<T002_CATEGORIA>(), "T002_ID_CATEGORIA", "T002_ID_CATEGORIA", t001_PRODUTO.T002_ID_CATEGORIA);
            ViewData["T003_ID_UF"] = new SelectList(_context.Set<T003_UF>(), "T003_ID_UF", "T003_ID_UF", t001_PRODUTO.T003_ID_UF);
            return View(t001_PRODUTO);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t001_PRODUTO = await _context.T001_PRODUTO
                .Include(t => t.T002_CATEGORIANavigation)
                .Include(t => t.T003_UFNavigation)
                .SingleOrDefaultAsync(m => m.T001_ID_PRODUTO == id);
            if (t001_PRODUTO == null)
            {
                return NotFound();
            }

            return View(t001_PRODUTO);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var t001_PRODUTO = await _context.T001_PRODUTO.SingleOrDefaultAsync(m => m.T001_ID_PRODUTO == id);
            _context.T001_PRODUTO.Remove(t001_PRODUTO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T001_PRODUTOExists(int id)
        {
            return _context.T001_PRODUTO.Any(e => e.T001_ID_PRODUTO == id);
        }

        //controles do plugin de upload
        FilesHelper filesHelper;
        String tempPath = "~/somefiles/";
        String serverMapPath = "~/Files/somefiles/";
        private string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }
        private string UrlBase = "/Files/somefiles/";
        String DeleteURL = "/FileUpload/DeleteFile/?file=";
        String DeleteType = "GET";


        public ActionResult Show()
        {
            JsonFiles ListOfFiles = filesHelper.GetFileList();
            var model = new FilesViewModel()
            {
                Files = ListOfFiles.files
            };

            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            var resultList = new List<ViewDataUploadFilesResult>();

            var CurrentContext = HttpContext;

            filesHelper.UploadAndShowResults(CurrentContext, resultList);
            JsonFiles files = new JsonFiles(resultList);

            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return Json("Error ");
            }
            else
            {
                return Json(files);
            }
        }
        public JsonResult GetFileList()
        {
            var list = filesHelper.GetFileList();
            return Json(list);
        }
        [HttpGet]
        public JsonResult DeleteFile(string file)
        {
            filesHelper.DeleteFile(file);
            return Json("OK");
        }
    }
}
