using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MDN.Data;
using MDN.Models.Entities;

namespace MDN.Controllers
{
    public class T001_PRODUTOController : Controller
    {
        private readonly DefaultDbContext _context;

        public T001_PRODUTOController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: T001_PRODUTO
        public async Task<IActionResult> Index()
        {
            return View(await _context.T001_PRODUTO.ToListAsync());
        }

        // GET: T001_PRODUTO/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t001_PRODUTO = await _context.T001_PRODUTO
                .SingleOrDefaultAsync(m => m.T001_ID_PRODUTO == id);
            if (t001_PRODUTO == null)
            {
                return NotFound();
            }

            return View(t001_PRODUTO);
        }

        // GET: T001_PRODUTO/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: T001_PRODUTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("T001_ID_PRODUTO,T001_TITULO,T001_DESCRICAO,T001_PRECO,T001_FOTO")] T001_PRODUTO t001_PRODUTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t001_PRODUTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(t001_PRODUTO);
        }

        // GET: T001_PRODUTO/Edit/5
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
            return View(t001_PRODUTO);
        }

        // POST: T001_PRODUTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("T001_ID_PRODUTO,T001_TITULO,T001_DESCRICAO,T001_PRECO,T001_FOTO")] T001_PRODUTO t001_PRODUTO)
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
            return View(t001_PRODUTO);
        }

        // GET: T001_PRODUTO/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t001_PRODUTO = await _context.T001_PRODUTO
                .SingleOrDefaultAsync(m => m.T001_ID_PRODUTO == id);
            if (t001_PRODUTO == null)
            {
                return NotFound();
            }

            return View(t001_PRODUTO);
        }

        // POST: T001_PRODUTO/Delete/5
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
    }
}
